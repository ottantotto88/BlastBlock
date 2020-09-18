
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject scoreText = null;
    [SerializeField] GameObject timeBar = null;
    [SerializeField] GameObject GameOverScreen = null;
    

    
    private Block[,] BlockGrid = new Block[8,8];
    private static Vector2 initialPos = new Vector2(-2.1f,2.1f);
    
    void Start()
    {
        InitializeGrid();
        scoreText.GetComponent<Text>().text = "0";

        
    }

    

    private void InitializeGrid() 
    {
        Vector2 internalGridPos = new Vector2(0, 0);
        Vector2 instancePosition = new Vector2(0, 0);
        GameObject currentInstance = null;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                internalGridPos.x = i * 0.6f;
                internalGridPos.y = -j * 0.6f;
                instancePosition = initialPos + internalGridPos;
                currentInstance = GetComponent<BlockFactory>().InstanceBlock(instancePosition);
                currentInstance.GetComponent<Block>().SetGM(this);
                currentInstance.GetComponent<Block>().SetIndex(new Vector2(i,j));
                BlockGrid[i,j] = currentInstance.GetComponent<Block>() as Block;
                
            }
        }
    }

    public Block[,] GetGrid() {
        return BlockGrid;
    }
    public Block GetGridElement(int i, int j)
    {
        i = Mathf.Clamp(i, 0, 7);
        j = Mathf.Clamp(j, 0, 7);
        return BlockGrid[i, j];
    }

    public BlockFactory GetBlockFactory() {
        return GetComponent<BlockFactory>();
    }

    public void ResetCheckGrid()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                BlockGrid[i, j].resetCheck();
            }
        }
    }

    public void IncreaseScore(int value)
    {

        scoreText.GetComponent<ScoreText>().IncreaseScore(value);
    }

    public void IncreaseTime(float toAdd) {
        timeBar.GetComponent<TimeBar>().IncreaseTime(toAdd);
    }

    public void GameOver() 
    {
        GameOverScreen.GetComponent<GameOverUI>().setYourScoreNum(scoreText.GetComponent<Text>().text);
        Instantiate(GameOverScreen, Vector2.zero, Quaternion.identity);
    }
}
