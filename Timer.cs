using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text displayTimeText;

    private float currentTime = 100;
    private float displayTime;

    public UnityEvent gameOverEvent;

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        displayTime = Mathf.Round(currentTime);
        displayTimeText.text = displayTime.ToString() + "s";
        
        if(currentTime < 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game over");
            gameOverEvent.Invoke();
            displayTimeText.text = "GAME OVER";
        }
    }
}
