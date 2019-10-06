using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChoose : MonoBehaviour {

    public Color[] colors;

    private int whichColor;
    private SpriteRenderer my_color;

    // Use this for initialization
    void Start()
    {
        whichColor = Random.Range(0, 4);
        my_color = gameObject.GetComponent<SpriteRenderer>();
        my_color.color = colors[whichColor];
    }

}
