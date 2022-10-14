using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
   // private Button button;
    public int difficulty;
   
    void Start()
    {
    //    button = GetComponent<Button>();
    //    button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void SetDifficulty()
    {

        Debug.Log ("Was clicked");
        GameManager.instance.Startgame(difficulty);
    }
}
