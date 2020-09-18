
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreText : MonoBehaviour
{
    [SerializeField] GameObject plusText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int value) 
    {
        plusText.GetComponent<Text>().text = "+" + value.ToString();
        plusText.SetActive(true);
        
        int newvalue = Int32.Parse(GetComponent<Text>().text) + value;
        GetComponent<Text>().text = newvalue.ToString();
    }
}
