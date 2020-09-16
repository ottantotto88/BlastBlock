using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] GameManager gameManager = null;
    private float timeLeft = 0;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 30f;
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
        Debug.Log(toAdd);
        timeLeft += toAdd;
    }
}
