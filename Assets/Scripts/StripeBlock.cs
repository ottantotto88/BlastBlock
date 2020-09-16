using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripeBlock : Block
{
    

    

    public override void OnTap()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnMouseDown()
    {
        gameManager.ResetCheckGrid();
        List<Block> toBlast = new List<Block>();

        toBlast = GetChain();

        int score = (toBlast.Count - 1) * 80 + (int) Mathf.Pow(((toBlast.Count - 2) / 5),2);
        gameManager.IncreaseScore(score);
        AddTime(toBlast.Count);
        foreach (Block block in toBlast)
            block.Blast();
    }

    public override List<Block> GetChain(BlockColor color)
    {
        List<Block> ResultList = new List<Block>();
        return ResultList;
    }

    public override List<Block> GetChain()
    {
        List<Block> result = new List<Block>();
        if (toCheck)
        {
            this.toCheck = false;
            result.Add(this);
            for (int i = 0; i < 8; i++)
                result.AddRange(gameManager.GetGridElement(i, (int)index.y).GetChain());
        }
        return result;
    }
}
