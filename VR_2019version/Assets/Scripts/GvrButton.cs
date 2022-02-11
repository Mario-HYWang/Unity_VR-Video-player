using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GvrButton : MonoBehaviour
{
    //public Image aimCircle;
    public UnityEvent gvrClick;
    float totalTime = 1f;
    bool gvrStatus;
    float gvrTimer;

    void Start()
    {
        //aimCircle.fillAmount = 0f;
    }

    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            //aimCircle.fillAmount = gvrTimer / totalTime;
        }

        if (gvrTimer >= totalTime)
        {
            gvrClick.Invoke();
            gvrStatus = false;
            gvrTimer = 0f;
            //aimCircle.fillAmount = 0f;
        }
    }
}
