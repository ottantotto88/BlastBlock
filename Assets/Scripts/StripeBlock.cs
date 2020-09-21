using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripeBlock : Block
{
    

    

    


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

    [System.Obsolete]
    public override void InstantiateEffect()
    {
        particleShatter.SetActive(true);
        particleShatter.transform.parent = gameObject.transform.parent;
    }

    public override List<Block> GetChainTM()
    {
        return GetChain();
    }
}
