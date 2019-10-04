using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreate_Infinite : MonoBehaviour {
    private static FoodCreate_Infinite _instance;
    public float[] x;
    public float[] y;
    private int number = 0;
    private int groupNumber = 0;
    public GameObject foodPerfabs;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        number = y.Length;
        groupNumber = x.Length;
        for (int i = 0; i < groupNumber; i++)
        {
            CreateFood(x[i]);
        }
    }

    public static FoodCreate_Infinite Instance
    {
        get
        {
            return _instance;
        }
    }

    public void CreateFood(float xpos)
    {
        for(int i=0;i<number;i++)
        {
            float isCreate = Random.Range(0f, 1.0f);
            if(isCreate>=0.4f)
            {
                GameObject food = Instantiate(foodPerfabs);
                food.transform.parent = this.transform;
                food.transform.localPosition = new Vector3(xpos, y[i], -0.05f);
            }
        }
    }
}
