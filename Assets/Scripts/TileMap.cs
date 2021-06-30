using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileMap : MonoBehaviour
{
    [SerializeField]
    private Tile tile;
    private Tile currentTile;
    private Tile[,] tiles;
    private MeshRenderer meshRenderer;
    private int gridthWidth = 20;
    private int gridHeight = 20;

   
    public int targetPoints = 9;
    public Vector2 randomPosition;
    public Tile[,] spawnTiles;
    public static int a = 0;
    public static int b = 0;
    public Color myColor;
    public GameManager manager;
    public List<Tile> selectedTiles = new List<Tile>();
  


    // Start is called before the first frame update
    private void Start()
    { 
        
        manager = GetComponent<GameManager>();
        InitializeTiles(); 
     
        meshRenderer = spawnTiles[0,0].gameObject.GetComponent<MeshRenderer>();    //initial position of the highlighter in grid
        meshRenderer.material.color = Color.cyan;

        currentTile = spawnTiles[0,0];
        myColor = Color.white;
    }

    private void Update()
    {
        KeyboardTraversal();
    }
    public void InitializeTiles()       //instantiates tile grid
    {
       spawnTiles = new Tile[gridthWidth, gridHeight];
       for(int i = 0; i < gridthWidth; i++)
       {
           for(int j = 0; j<gridHeight; j++)
           {
             Tile temp = Instantiate(tile, new Vector2(i,j), Quaternion.identity);
             spawnTiles[i,j] = temp;
             temp.index = new Vector2(i,j);
             temp.tileMap = this;

           }
       }
       
       for(int i = 0; i<= targetPoints; i++)
       {
           int tempA = Random.Range(0, spawnTiles.GetLength(0) -1);
           int tempB = Random.Range(0, spawnTiles.GetLength(1) -1);
           spawnTiles[tempA, tempB].isSelected = true;

           
           selectedTiles.Add(spawnTiles[tempA, tempB]);     // adds 10 tiles to selectedTiles list
           if(selectedTiles[i].index.x < spawnTiles.GetLength(0) && selectedTiles[i].index.y+1 < spawnTiles.GetLength(1))
           {
            Vector2 temp1 = new Vector2(selectedTiles[i].index.x, selectedTiles[i].index.y+1);   //gets adjacent top tiles from the selected tiles
            spawnTiles[(int)temp1.x, (int)temp1.y].isAdjecent = true; 
           }
           if(selectedTiles[i].index.x < spawnTiles.GetLength(0) && selectedTiles[i].index.y-1 > 0)
           {
            Vector2 temp2 = new Vector2(selectedTiles[i].index.x, selectedTiles[i].index.y-1);   //gets adjacent bottom tiles from the selected tiles
            spawnTiles[(int)temp2.x, (int)temp2.y].isAdjecent = true;
           }
           if(selectedTiles[i].index.x+1 < spawnTiles.GetLength(0) && selectedTiles[i].index.y < spawnTiles.GetLength(1))
           {
            Vector2 temp3 = new Vector2(selectedTiles[i].index.x+1, selectedTiles[i].index.y);   //gets adjacent right tiles from the selected tiles
            spawnTiles[(int)temp3.x, (int)temp3.y].isAdjecent = true;


           }
           if(selectedTiles[i].index.x-1 > 0 && selectedTiles[i].index.y < spawnTiles.GetLength(1))
           {
           Vector2 temp4 = new Vector2(selectedTiles[i].index.x-1, selectedTiles[i].index.y);   //gets adjacent left tiles from the selected tiles
           spawnTiles[(int)temp4.x, (int)temp4.y].isAdjecent = true;       //setting isAdjecent bool to true for changing adjecent tile's color in Tile.cs


           }
           if(selectedTiles[i].index.x < spawnTiles.GetLength(0) && selectedTiles[i].index.y+2 < spawnTiles.GetLength(1))
           {
           Vector2 temp5 = new Vector2(selectedTiles[i].index.x, selectedTiles[i].index.y+2);   //gets adjacent top 2nd tiles from the selected tiles
           spawnTiles[(int)temp5.x, (int)temp5.y].isAdjecent = true;


           }
           if(selectedTiles[i].index.x < spawnTiles.GetLength(0) && selectedTiles[i].index.y-2 > 0)
           {
           Vector2 temp6 = new Vector2(selectedTiles[i].index.x, selectedTiles[i].index.y-2);   //gets adjacent bottom 2nd tiles from the selected tiles
           spawnTiles[(int)temp6.x, (int)temp6.y].isAdjecent = true;
            
           }
           if(selectedTiles[i].index.x+2 < spawnTiles.GetLength(0) && selectedTiles[i].index.y < spawnTiles.GetLength(1))
           {
           Vector2 temp7 = new Vector2(selectedTiles[i].index.x+2, selectedTiles[i].index.y);   //gets adjacent right 2nd tiles from the selected tiles
           spawnTiles[(int)temp7.x, (int)temp7.y].isAdjecent = true;
           
           }
           if(selectedTiles[i].index.x-2 > 0 && selectedTiles[i].index.y < spawnTiles.GetLength(1))
           {
           Vector2 temp8 = new Vector2(selectedTiles[i].index.x-2, selectedTiles[i].index.y);   //gets adjacent left 2nd tiles from the selected tiles
           spawnTiles[(int)temp8.x, (int)temp8.y].isAdjecent = true;

           }

                

          
       }
    }

   public void KeyboardTraversal()
   { 
       if(Input.GetKeyDown(KeyCode.Space))        //uncovering the tile using space key
       {
           manager.clickCount++;
           spawnTiles[b,a].Selected();
           myColor = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>().material.color;
       }
       
   
        else if(Input.GetKeyDown(KeyCode.W) && a+1 < spawnTiles.GetLength(1))           //moving the highlighter up the column for selection
        {
  
           currentTile.gameObject.GetComponent<MeshRenderer>().material.color = myColor;          
           a += 1;
           currentTile = spawnTiles[b,a];

           myColor = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>().material.color;
        
           meshRenderer = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>();   
           meshRenderer.material.color = Color.cyan;
       
        }
        
        else if(Input.GetKeyDown(KeyCode.S) && a-1 >= 0)             //moving the highlighter down the column for selection
        {
            
           currentTile.gameObject.GetComponent<MeshRenderer>().material.color = myColor;
           a -= 1;
           currentTile = spawnTiles[b,a];
           myColor = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>().material.color;
            
           meshRenderer = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>();   
           meshRenderer.material.color = Color.cyan;

        }

        else if(Input.GetKeyDown(KeyCode.D) && b+1 < spawnTiles.GetLength(0))            //moving the highlighter right in the row for selection
        {
            
            currentTile.gameObject.GetComponent<MeshRenderer>().material.color = myColor;

            b += 1;
            currentTile = spawnTiles[b,a];
            myColor = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>().material.color;

            meshRenderer = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>();   
            meshRenderer.material.color = Color.cyan;

        }

        else if(Input.GetKeyDown(KeyCode.A) && b-1 >= 0)             //moving the highlighter left in the row for selection
        {
            currentTile.gameObject.GetComponent<MeshRenderer>().material.color = myColor; 
            b -= 1;
            currentTile = spawnTiles[b,a];
            myColor = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>().material.color;

            meshRenderer = spawnTiles[b,a].gameObject.GetComponent<MeshRenderer>();   
            meshRenderer.material.color = Color.cyan;

        }
      
   }
}
  