using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornMove : MonoBehaviour {

    public float oriXpos = 0f;
    public float oriYpos = 0f;
    public float yOffset = 0f;
    public float xOffset = 0f;
    public float maxXpos = 0f;
    public float maxYpos = 0f;
    public int mode = 0;

    private float time;
    private float deltatime;

    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.position = new Vector3(oriXpos, oriYpos, 0f);
        time = Time.time;
        deltatime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mode == 0)
            MoveMode_0();
        else if (mode == 1)
            MoveMode_1();
    }

    void MoveMode_0()
    {
        float x = oriXpos + xOffset * ((float)Math.Sin(Time.time * Time.deltaTime * 180 / 3.1415926) > 0 ? (float)Math.Sin(Time.time * Time.deltaTime * 180 / 3.1415926) : 0);
        float y = oriYpos + yOffset * ((float)Math.Sin(Time.time * Time.deltaTime * 180 / 3.1415926) > 0 ? (float)Math.Sin(Time.time * Time.deltaTime * 180 / 3.1415926) : 0);
        this.gameObject.transform.position = new Vector3(x, y, 0f);
    }

    void MoveMode_1()
    {
        deltatime = Time.time - time;
        float x = xOffset * deltatime * Time.deltaTime * 18f;
        float y = yOffset * deltatime * Time.deltaTime * 18f;
        if ((x > 0 ? x : -x) > maxXpos)
        {
            x = 0;
            time = Time.time;
        }   
        if ((y > 0 ? y : -y) > maxYpos)
        {
            y = 0;
            time = Time.time;
        }
        this.gameObject.transform.position = new Vector3(oriXpos + x, oriYpos + y, 0f);
    }
}
