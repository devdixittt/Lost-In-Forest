using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    public Text highestScore;
    void Start()
    {
        GM = GetComponent<GameManager>();
        highestScore.text = "Highest Score: " + PlayerPrefs.GetInt("Highest Score", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateScore()
    {
        if(GM.Score > PlayerPrefs.GetInt("Highest Score", 0)){
            PlayerPrefs.SetInt("Highest Score", GM.Score);
        }
    }
}
