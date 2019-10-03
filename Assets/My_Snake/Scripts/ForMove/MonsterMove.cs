using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public float oriXpos = 0f;
    public float oriYpos = 0f;
    public float yOffset = 0f;
    public float xOffset = 0f;

    // Use this for initialization
    void Start () {
        this.gameObject.transform.position = new Vector3(oriXpos, oriYpos, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = oriXpos + xOffset * (float)Math.Sin(Time.time * Time.deltaTime* 180 / 3.1415926);
        float y = oriYpos + yOffset * (float)Math.Sin(Time.time * Time.deltaTime * 180 / 3.1415926);
        this.gameObject.transform.position = new Vector3(x, y, 0f);
    }
}
