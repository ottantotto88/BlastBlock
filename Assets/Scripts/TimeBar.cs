using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private GameObject plusText = null;
    [SerializeField] private float timeLeft = 0;
    
    private bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            if (!gameOver)
            {
                gameOver = true;
                gameManager.GameOver();
            }
        }
        else
            GetComponent<Slider>().value = timeLeft;
    }

    public void IncreaseTime(float toAdd) 
    {
        plusText.GetComponent<Text>().text = "+" + (int)toAdd + "''";

        if ((int)toAdd > 0)
        {
            GameObject ptInstance = Instantiate(plusText, new Vector3(0, 0, -93), Quaternion.identity);
            ptInstance.GetComponent<RectTransform>().SetParent(transform);
            ptInstance.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
        }
        timeLeft += toAdd;
    }
}
