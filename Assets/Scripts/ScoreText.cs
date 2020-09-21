
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreText : MonoBehaviour
{
    [SerializeField] GameObject plusText = null;
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

        GameObject ptInstance = Instantiate(plusText);
        ptInstance.GetComponent<RectTransform>().SetParent(transform);
        ptInstance.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);

        int newvalue = Int32.Parse(GetComponent<Text>().text) + value;
        GetComponent<Text>().text = newvalue.ToString();
    }
}
