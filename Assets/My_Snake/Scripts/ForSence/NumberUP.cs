using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberUP : MonoBehaviour {

    public GameObject numbertext;
    public int mode = 0;
    private SnakeHead_Infinite sh;
    private TextMesh Text;
    private int value = 0;

    void Start()
    {
        GameObject snakeh = GameObject.Find("Snake/snakehead");
        sh = snakeh.GetComponent<SnakeHead_Infinite>();
        if(sh!=null)
            value = sh.GetBodyLength();
        Text = numbertext.GetComponent<TextMesh>();
        if(mode==0)
        {
            value = (int)Random.Range(1, value * 1.2f + 10);
            Text.text = "" + value;
        }
        else if(mode==1)
        {
            value = (int)Random.Range(1, 10);
            Text.text = "" + value;
        }
    }

    public int Value
    {
        get
        {
            return value;
        }
    }
}
