using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPool : MonoBehaviour {

    private static ToolPool _instance;
    public float xmax;
    public float xmin;
    public float ymax;
    public float ymin;
    public int number=0;
    public int wallnumber = 0;
    public GameObject[] toolPerfabs;
    public GameObject[] wallPerfabs;
    private Transform toolHolder;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        toolHolder = GameObject.Find("ToolHolder").transform;
        for(int i=0;i<number;i++)
        {
            CreateTool();
        }
        for (int i = 0; i < wallnumber; i++)
        {
            CreateWall();
        }
    }

    public static ToolPool Instance
    {
        get
        {
            return _instance;
        }
    }

    public void CreateTool()
    {
        int index = Random.Range(0, toolPerfabs.Length);
        GameObject tool = Instantiate(toolPerfabs[index]);
        tool.transform.SetParent(toolHolder, false);
        float x = Random.Range(xmin, xmax);
        float y = Random.Range(ymin, ymax);
        tool.transform.position = new Vector3(x, y, -0.05f);
    }
    public void CreateWall()
    {
        int index = Random.Range(0, wallPerfabs.Length);
        GameObject tool = Instantiate(wallPerfabs[index]);
        tool.transform.SetParent(toolHolder, false);
        float x = Random.Range(xmin, xmax);
        float y = Random.Range(ymin, ymax);
        tool.transform.position = new Vector3(x, y, -0.05f);
    }
}
