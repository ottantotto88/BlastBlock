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
        throw new System.NotImplementedException();
    }

    public override List<Block> GetChain(BlockColor color)
    {
        List<Block> ResultList = new List<Block>();
        return ResultList;
    }
}
