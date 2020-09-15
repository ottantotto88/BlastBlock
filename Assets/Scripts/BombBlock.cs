using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlock : Block
{
    
    
    override public void OnTap() { 
    }

    

    protected override void OnMouseDown()
    {
        gameManager.ResetCheckGrid();
        List<Block> toBlast = new List<Block>();

        toBlast = GetChain();

        foreach (Block block in toBlast)
            block.Blast();



    }

    public override List<Block> GetChain(BlockColor color)
    {
      
        toCheck = false;
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
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    result.AddRange(gameManager.GetGridElement((int)index.x + i, (int)index.y + j).GetChain());
        }
        return result;
    }

}
