using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusText : MonoBehaviour
{
    public void OnAnimationFinished() 
    {
        gameObject.SetActive(false);
    }
}