
using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Block : MonoBehaviour
{
    [SerializeField] protected GameObject particleShatter = null;
    public enum BlockColor { RED, BLUE, GREEN, YELLOW, VIOLET, ORANGE}
    protected GameManager gameManager;
    protected static System.Random rnd = new System.Random();
    protected SpriteRenderer spriteRenderer;
    protected static Color _orange = new Color(1.0f, 0.64f, 0.0f);
    protected Vector2 index;
    protected bool toCheck = true;
    public abstract void OnTap();
    public void Blast() 
    {
        InstantiateEffect();

        GameObject newInstance = 
            gameManager.GetBlockFactory().InstanceBlock(gameObject.transform.position);
        gameManager.GetGrid()[(int)index.x, (int)index.y] = newInstance.GetComponent<Block>();
        newInstance.GetComponent<Block>().SetIndex(index);
        newInstance.GetComponent<Block>().SetGM(gameManager);
        if(gameObject != null)
            Destroy(gameObject);
    }

    protected abstract void OnMouseDown();
    public  void SetGM(GameManager gameManager) {
        this.gameManager = gameManager;
    }

    public void SetIndex(Vector2 index) {
        this.index = index;
    }

    public abstract List<Block> GetChain(BlockColor color);
    public abstract List<Block> GetChain();

    public void resetCheck() {
        toCheck = true;
    }

    public void AddTime(int blockCount)
    { 
        float time = (Mathf.Pow(((blockCount - 2) / 3),2) * 20)/10;
        gameManager.IncreaseTime(time);
    }
    [Obsolete]
    public abstract void InstantiateEffect();
}
