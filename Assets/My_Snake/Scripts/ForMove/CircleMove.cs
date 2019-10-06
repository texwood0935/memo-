using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour {

    public float oriXpos = 0f;
    public float oriYpos = 0f;
    public float yOffset = 0f;
    public float maxYpos = 0f;

    private float time;
    private float deltatime;
    private int flag;

    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.localPosition = new Vector3(oriXpos, oriYpos, 0f);
        time = Time.time;
        deltatime = 0;
        flag = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveMode_1();
    }

    void MoveMode_1()
    {
        deltatime = Time.time - time;
        float y = yOffset * deltatime * Time.deltaTime * 18f;
        if(flag==1)
            y = yOffset - yOffset * deltatime * Time.deltaTime * 18f;
        if ((y > 0 ? y : -y) > maxYpos && flag == 0)
        {
            time = Time.time;
            flag = 1;
        }
        else if (((yOffset < 0 && y > 0) ||(yOffset>0 && y < 0)) && flag == 1)
        {
            flag = 0;
            time = Time.time;
        }
        this.gameObject.transform.localPosition = new Vector3(oriXpos, oriYpos + y, 0f);
    }
}
