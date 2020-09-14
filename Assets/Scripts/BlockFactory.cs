using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory :MonoBehaviour
{
    [SerializeField] private GameObject colorBlock = null;
    [SerializeField] private GameObject stripeBlock = null;
    [SerializeField] private GameObject bombBlock = null;

    protected static System.Random rnd = new System.Random();
    public GameObject InstanceBlock(Vector2 instancePos) 
    {
        int rng = rnd.Next(0, 100);
        if (rng < 95)
            return Instantiate(colorBlock, instancePos, Quaternion.identity);
        else
        {
            rng = rnd.Next(0, 100);
            if (rng < 50)
                return Instantiate(stripeBlock, instancePos, Quaternion.identity);
            else
                return Instantiate(bombBlock, instancePos, Quaternion.identity);
        }
            

    }
}
