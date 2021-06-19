using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Button_Start : Custom_Button
{
    List<Timer> timers = new List<Timer>();
    string shakeTimer = "shakeTimer";

    void Update()
    {
        UpdateTimers();
    }

    public void MouseOver()
    {
        StartShake();
    }
    public void MouseEnter()
    {
        StartShake();
    }
    public void MouseExit()
    {
        StopShake();
    }
    void UpdateTimers()
    {
        for (int i = timers.Count - 1; i >= 0; i--)
        {
            if (timers[i].Run())
            {
                if (!timers[i].IsRepeating)
                {
                    timers.RemoveAt(i);
                }
            }
        }
    }
    Timer FindTimer(string id)
    {
        for (int i = timers.Count - 1; i >= 0; i--)
        {
            if (timers[i].ID == id)
            {
                return timers[i];
            }
        }
        return null;
    }
    bool RemoveTimer(string id)
    {
        for (int i = timers.Count - 1; i >= 0; i--)
        {
            if (timers[i].ID == id)
            {
                timers.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    void StartShake()
    {
        if (FindTimer(shakeTimer) == null)
        {
            buttonText.fontStyle = FontStyle.Bold;
            timers.Add(new Timer(shakeTimer, true, .3f, Shake, true));
        }
    }
    void Shake()
    {
        if (buttonText.transform.rotation.z > 0)
        {
            RotateText(-10);
        }
        else
        {
            RotateText(10);
        }
    }
    void RotateText(float zAngle)
    {
        buttonText.transform.localRotation = Quaternion.Euler(0, 0, zAngle);
    }
    void StopShake()
    {
        if (RemoveTimer(shakeTimer))
        {
            RotateText(0);

            buttonText.fontStyle = FontStyle.Normal;
        }
    }
}
