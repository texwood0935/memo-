using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsColorLineActive : MonoBehaviour {

    public GameObject colorline;

	// Use this for initialization
	void Start () {
        colorline.SetActive(false);
        int i = Random.Range(1, 10);
        if (i > 4)
            colorline.SetActive(true);
	}
}
