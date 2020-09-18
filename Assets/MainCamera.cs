using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject mouseEffect = null;

    private Vector3 target = Vector3.zero;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            target = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            target.z = -4;
            mouseEffect.transform.position = target;
            
            mouseEffect.SetActive(true);
        }
    }
}
