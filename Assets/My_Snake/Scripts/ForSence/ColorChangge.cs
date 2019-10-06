using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangge : MonoBehaviour {

    public Color[] colors;
    public float speed;

    private float timebegin;
    private bool isCollide;
    private int whichColor;
    private SpriteRenderer my_color;

	// Use this for initialization
	void Start () {
        timebegin = Time.time;
        isCollide = false;
        whichColor = Random.Range(1, 4);
        my_color = gameObject.GetComponent<SpriteRenderer>();
        my_color.color = colors[whichColor];
	}
	
	// Update is called once per frame
	void Update () {
		if(!isCollide&&Time.time-timebegin>speed)
        {
            whichColor++;
            if (whichColor > 3)
                whichColor = 0;
            my_color.color = colors[whichColor];
            timebegin = Time.time;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "snake")
            isCollide = true;
    }
}
