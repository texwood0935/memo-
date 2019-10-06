using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDiaColorChoose : MonoBehaviour {

    public Color[] colors;
    public GameObject[] diaColors;

    private int whichColor;
    private SpriteRenderer my_color;
    private int[,] which =
    {
        {1,2,3,4 },
        {1,2,4,3 },
        {1,3,2,4 },
        {1,4,2,3 },
        {1,3,4,2 },
        {1,4,3,2 },
        {2,1,3,4 },
        {2,1,4,3 },
        {2,3,1,4 },
        {2,4,1,3 },
        {2,3,4,1 },
        {2,4,3,1 },
        {3,1,2,4 },
        {3,1,4,2 },
        {3,2,1,4 },
        {3,4,1,2 },
        {3,2,4,1 },
        {3,4,2,1 },
        {4,1,2,3 },
        {4,1,3,2 },
        {4,2,1,3 },
        {4,3,1,2 },
        {4,2,3,1 },
        {4,3,2,1 }
    };

    // Use this for initialization
    void Start()
    {
        whichColor = Random.Range(0, which.Length/4);
        for(int i=0;i<4;i++)
        {
            my_color = diaColors[i].GetComponent<SpriteRenderer>();
            Debug.Log(i + ":" + which[whichColor, i]);
            my_color.color = colors[which[whichColor,i]-1];
            if (diaColors.Length > 4)
            {
                my_color = diaColors[i + 4].GetComponent<SpriteRenderer>();
                my_color.color = colors[which[whichColor, i]-1];
            }
        }
    }

}
