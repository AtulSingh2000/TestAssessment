using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int clickCount = 0;
    public int totalClicks;
    public Text clicksLeft;
    public GameObject UIPanel;
    // Start is called before the first frame update
    void Start()
    {
        UIPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        clicksLeft.text = "Attempts remaining: " +(totalClicks - clickCount);
   
      if(clickCount>=20)
       {
          UIPanel.SetActive(true);
       }


    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
