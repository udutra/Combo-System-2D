using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{

    public static SlowDown instance;
    public float slowDownTime;
    private bool canSlownDown;
    private float timer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (canSlownDown)
        {
            timer += Time.unscaledDeltaTime;
            Time.timeScale += Time.unscaledDeltaTime / slowDownTime;
            if(timer >= slowDownTime)
            {
                canSlownDown = false;
                Time.timeScale = 1;
            }
        }
    }

    public void SetSlowDown()
    {
        Time.timeScale = 0;
        canSlownDown = true;
        timer = 0;
    }
}
