using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll : MonoBehaviour {

    public float speed;
    public float yPos;
    public float XPos_Begin;
    public float XPos_End;
    public GameObject BGPerfabs;
    public Transform BGFather;
    private Transform BGHolder;

    void Start()
    {
        BGHolder = GameObject.Find("BG").transform;
        GameObject backG = Instantiate(BGPerfabs);
        backG.transform.SetParent(BGHolder, false);
        backG.transform.localPosition = new Vector3(XPos_Begin, yPos, 0);
    }

    void FixedUpdate()
    {
        BGMove();
    }

    void BGMove()
    {
        for(int i=0;i<2;i++)
        {
            var child = BGFather.GetChild(i).gameObject;
            child.transform.localPosition = child.transform.localPosition + new Vector3(speed * 0.02f, 0, 0);
            if(child.transform.localPosition.x<XPos_End)
            {
                Destroy(child);
                CreateBG();
            }
        }
    }

    void CreateBG()
    {
        GameObject backG = Instantiate(BGPerfabs);
        backG.transform.SetParent(BGHolder, false);
        backG.transform.localPosition = new Vector3(XPos_Begin, yPos, 0);
    }
}
