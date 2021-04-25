using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLimiter : MonoBehaviour
{
    private float timer = 0.0f;
    private float interval = 10f;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public bool GetCanSpeak()
    {
        return timer < 0.0f;
    }

    public void SetCanSpeak(bool value)
    {
        if (value)
        {
            timer = -1.0f;
        }
        else
        {
            timer = interval;
        }
    }
}
