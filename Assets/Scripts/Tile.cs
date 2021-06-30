 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField]
    private List<Sprite> tileSprites;
    private MeshRenderer sb;
    
    
    public bool isSelected = false;
    public bool isHighlighted = false;
    public bool isAdjecent = false;
    
    public TileMap tileMap;
    public Vector2 index;
  
   
    
  void Awake()
  {
      sb = GetComponent<MeshRenderer>();    
  }

  void OnMouseOver()
  {
         
      if(Input.GetMouseButtonDown(0))
      {
           tileMap.manager.clickCount++;
        
           if(isSelected)
           {
               sb.material.color = Color.red;
           }
            else if(isAdjecent) 
           {
               sb.material.color = Color.yellow;
           }
           else
           {
               sb.material.color = Color.green;
           }

      }
    
  } 

  public void Selected()
  { 
     if(isSelected)
           {    
             gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
           }
            else if(isAdjecent) 
           {
             gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
           }
           else
           {
             gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
           }

  }
 
}


