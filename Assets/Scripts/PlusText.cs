using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusText : MonoBehaviour
{
    public void OnAnimationFinished() 
    {
        Destroy(gameObject);
    }

    public void OnClickAnimationFinished()
    {
        gameObject.SetActive(false);
    }
}