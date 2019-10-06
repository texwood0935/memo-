using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCreate : MonoBehaviour {

    public GameObject[] colorPerfabs;

    private int which;

	void Start () {
        which = Random.Range(0, colorPerfabs.Length);
        GameObject food = Instantiate(colorPerfabs[which]);
        food.transform.parent = this.transform;
        food.transform.localPosition = new Vector3(-2, -0.03266243f, 0);
    }
}
