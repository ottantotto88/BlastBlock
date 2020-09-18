using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject YourScoreNum = null;
    [SerializeField] GameObject BestScoreNum = null;

    private int bestScore, yourScore;
    // Start is called before the first frame update
    void Start()
    {
        bestScore = DBManager.ReadBestScore();
        BestScoreNum.GetComponent<Text>().text = bestScore.ToString();
    }

   

    public void setYourScoreNum(string score)
    {
        bestScore = DBManager.ReadBestScore();
        BestScoreNum.GetComponent<Text>().text = bestScore.ToString();
        yourScore = Int32.Parse(score);
        YourScoreNum.GetComponent<Text>().text = score;
        if (yourScore > bestScore) 
            DBManager.InsertBestScore(yourScore);
            //TODO: DB INSERTION;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadGridLevel()
    {
        SceneManager.LoadScene("GridLevel");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

   
}
