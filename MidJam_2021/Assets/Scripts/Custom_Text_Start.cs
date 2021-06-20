using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Text_Start : MonoBehaviour
{
    Text text;
    Timer timer;
    [SerializeField] float minShakeAngle;
    [SerializeField] float maxShakeAngle;

    void Awake()
    {
        text = GetComponent<Text>();
        timer = new Timer("shakeTimer", true, .5f, Shake, true);

        if (Random.Range(0, 2) > 0)
        {
            text.transform.localRotation = Quaternion.Euler(0, 0, 1);
        }
    }
    void Update()
    {
        timer.Run();
    }
    void Shake()
    {
        float angle = Random.Range(minShakeAngle, maxShakeAngle);
        if (text.transform.rotation.z > 0)
        {
            angle = -Mathf.Abs(angle);
        }
        else
        {
            angle = Mathf.Abs(angle);
        }
        RotateText(angle);
    }
    void RotateText(float zAngle)
    {
        text.transform.localRotation = Quaternion.Euler(0, 0, zAngle);
    }
}
