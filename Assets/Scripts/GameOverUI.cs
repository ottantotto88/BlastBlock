﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject YourScoreNum = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setYourScoreNum(string score)
    {
        YourScoreNum.GetComponent<Text>().text = score;
    }

    public void ReloadScene()
    {
        Debug.Log("clicco");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadGridLevel()
    {
        Debug.Log("clicco");
        SceneManager.LoadScene("GridLevel");
    }
}