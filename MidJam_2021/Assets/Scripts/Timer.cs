using UnityEngine;
using System;

public class Timer
{
    string id = "";
    float timeStart;
    public float time;
    float elapsedTime = 0;
    bool on;
    bool reset;
    bool repeat = false;
    public event Action action;

    public string ID
    {
        get
        {
            return id;
        }
    }
    public bool IsRepeating
    {
        get
        {
            return repeat;
        }
        set
        {
            repeat = value;
        }
    }
    public bool IsOn
    {
        get
        {
            return on;
        }
    }
    public bool IsReset
    {
        get
        {
            return reset;
        }
    }
    public float StartTime
    {
        get
        {
            return timeStart;
        }
    }
    public float ElapsedTime
    {
        get
        {
            return elapsedTime;
        }
    }
    public float RemainingTime
    {
        get
        {
            return time - elapsedTime;
        }
    }

    public Timer(bool _repeat)
    {
        Reset();
        repeat = _repeat;
    }
    public Timer(Action _action, bool _repeat)
    {
        Reset();
        repeat = _repeat;
        action += _action;
    }
    public Timer(bool start, float _time, bool _repeat)
    {
        Reset();
        time = _time;
        if (start)
        {
            Start();
        }
        repeat = _repeat;
    }
    public Timer(string _id, bool start, float _time, Action _action, bool _repeat)
    {
        id = _id;
        Reset();
        time = _time;
        if (start)
        {
            Start();
        }
        repeat = _repeat;
        action += _action;
    }

    public void SetName(string _id)
    {
        id = _id;
    }
    public void Start()
    {
        timeStart = Time.time;
        elapsedTime = 0;
        on = true;
        reset = false;
    }
    public void Start(float _time)
    {
        timeStart = Time.time;
        elapsedTime = 0;
        time = _time;
        on = true;
        reset = false;
    }
    public void StartRandom(float minTime, float maxTime)
    {
        timeStart = Time.time;
        elapsedTime = 0;
        on = true;
        reset = false;
        time = UnityEngine.Random.Range(minTime, maxTime);
    }
    public bool Run()
    {
        if (on)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= time)
            {
                InvokeAction();

                if (repeat)
                {
                    Start(time);
                }
                else
                {
                    Stop();
                }
                return true;
            }
        }
        return false;
    }
    public void Stop()
    {
        on = false;
    }
    public void Resume()
    {
        on = true;
    }
    public void Restart()
    {
        on = true;
        elapsedTime = 0;
    }
    public void Reset()
    {
        timeStart = 0;
        time = 0;
        elapsedTime = 0;
        on = false;
        reset = true;
    }
    public void AddAction(Action _action)
    {
        action += _action;
    }
    public void InvokeAction()
    {
        if (action != null)
        {
            action.Invoke();
        }
    }
}
