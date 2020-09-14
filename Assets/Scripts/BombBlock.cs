using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlock : Block
{
    
    
    override public void OnTap() { 
    }

    

    protected override void OnMouseDown()
    {
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                gameManager.GetGridElement((int)index.x + i, (int)index.y + j).Blast();


    }

    public override List<Block> GetChain(BlockColor color)
    {
      
        toCheck = false;
        List<Block> ResultList = new List<Block>();
        return ResultList;
    }
}
