using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour {

    private float timer = 0.0f;
    private float timer2 = 0.0f;
    public static float bobbingSpeedX = 0.26f;
    public static float bobbingSpeedY = 0.18f;
    //public static float bobbingSpeed = 0.18f;
    private float bobbingAmountX = 0.10f;
    private float bobbingAmountY = 0.13f;
    float midpoint = 1.0f;

    float waveslice, horizontal, vertical, translateChange, totalAxes, localPosition;
    float waveslice2, totalAxes2, translateChange2;
    void Update()
    {
        waveslice = 0.0f;
        waveslice2 = 0.0f;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
            timer2 = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeedY;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }

            waveslice2 = Mathf.Cos(timer2);
            timer2 = timer2 + bobbingSpeedX;
            if (timer2 > Mathf.PI * 2)
            {
                timer2 = timer2 - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0 && waveslice2 != 0)
        {
            translateChange = waveslice * bobbingAmountY;
            totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;

            translateChange2 = waveslice2 * bobbingAmountX;
            totalAxes2= Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes2 = Mathf.Clamp(totalAxes2, 0.0f, 1.0f);
            translateChange2 = totalAxes2 * translateChange2;

            transform.localPosition = new Vector3(translateChange2, midpoint + translateChange,0.0f);
        }
        else
        {
            transform.localPosition = new Vector3(0.0f, midpoint, 0.0f);
        }


    }
}
