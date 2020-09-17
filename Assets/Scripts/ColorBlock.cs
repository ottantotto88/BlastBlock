
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : Block
{
    BlockColor mColor;


    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeColor();
    }

    protected void InitializeColor()
    {
        mColor = (BlockColor)rnd.Next(0, 6);
        switch (mColor)
        {
            case BlockColor.RED:
                spriteRenderer.color = Color.red;
                break;
            case BlockColor.BLUE:
                spriteRenderer.color = Color.blue;
                break;
            case BlockColor.GREEN:
                spriteRenderer.color = Color.green;
                break;
            case BlockColor.YELLOW:
                spriteRenderer.color = Color.yellow;
                break;
            case BlockColor.VIOLET:
                spriteRenderer.color = Color.magenta;
                break;
            case BlockColor.ORANGE:
                spriteRenderer.color = _orange;
                break;

        }
    }
    protected override void OnMouseDown()
    {
        gameManager.ResetCheckGrid();
        List<Block> colorChain = GetChain(mColor);
        Debug.Log(colorChain.Count);
        if (colorChain.Count > 1)
        {
            int score = (colorChain.Count - 1) * 80 + (int)Mathf.Pow(((colorChain.Count - 2) / 5), 2);
            gameManager.IncreaseScore(score);
            AddTime(colorChain.Count);
            foreach (Block iblock in colorChain)
                iblock.Blast();

        }
        
    }

    public override List<Block> GetChain(BlockColor color)
    {
        List<Block> ResultList = new List<Block>();
        if (this.mColor == color && toCheck)
        {
            toCheck = false;
            ResultList.Add(this);

            ResultList.AddRange(gameManager.GetGridElement((int)index.x - 1, (int)index.y).GetChain(this.mColor));
            ResultList.AddRange(gameManager.GetGridElement((int)index.x + 1, (int)index.y).GetChain(this.mColor));
            ResultList.AddRange(gameManager.GetGridElement((int)index.x, (int)index.y - 1).GetChain(this.mColor));
            ResultList.AddRange(gameManager.GetGridElement((int)index.x, (int)index.y + 1).GetChain(this.mColor));

        }

        return ResultList;
    }



    public override void OnTap()
    {

    }

    public override List<Block> GetChain()
    {
        List<Block> result = new List<Block>();
        if (toCheck)
        {
            this.toCheck = false;
            result.Add(this);
        }
        return result;
    }

    [System.Obsolete]
    public override void InstantiateEffect()
    {
        particleShatter.GetComponent<ParticleSystem>().startColor = spriteRenderer.color;
        particleShatter.SetActive(true);
        particleShatter.transform.parent = gameObject.transform.parent;
    }
}