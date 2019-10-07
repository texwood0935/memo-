using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRiskMap : MonoBehaviour {

    public GameObject[] wall;
    public GameObject[] tool;
    public GameObject[] food;
    public GameObject snakehead;
    public float yMin = 10;
    public float xMin = 10;
    public float yMax = 10;
    public float xMax = 10;
    public float z = 10;
    public float step = 0.1f;
    public int wallNum = 10;
    public int toolNum = 10;
    public int foodNum = 10;

    private Transform Map;
    private List<Vector3> MapPosList = new List<Vector3>();
    private List<Vector3> toolPosList = new List<Vector3>();
    private List<Vector3> wallPosList = new List<Vector3>();
    private List<Vector3> foodPosList = new List<Vector3>();
    private static CreateRiskMap _instance;

    public static CreateRiskMap Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
        MapInit();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void MapInit()
    {
        Map = new GameObject("Map").transform;

        //地图位置列表创建
        MapPosList.Clear();
        for (float x = xMin; x < xMax; x+=step)
        {
            for (float y = yMin; y < yMax; y += step)
            {
                MapPosList.Add(new Vector3(x, y, z));
            }
        }
        snakehead.transform.position = RandomPos();
        for (float x = snakehead.transform.position.x-step*4; x < snakehead.transform.position.x + step * 4; x += step)
        {
            for (float y = snakehead.transform.position.y - step * 4; y < snakehead.transform.position.y + step * 4; y += step)
            {
                if (x < xMin || y < yMin || x > xMax || y > yMax)
                    continue;
                MapPosList.Remove(new Vector3(x, y, z));
            }
        }
        //创建障碍物
        CreateObject(wallNum, wall, 0);

        //创建道具
        CreateObject(toolNum, tool, 1);

        //创建食物
        CreateObject(foodNum, food, 2);
    }


    //游戏物体实力化方法
    private void CreateObject(int num, GameObject[] my_object, int which)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject.Instantiate(RandomObject(my_object), RandomPos(which), Quaternion.identity).transform.SetParent(Map);
        }
    }

    //取随机位置方法
    private Vector3 RandomPos(int which=3)
    {
        int index = Random.Range(0, MapPosList.Count);
        Vector3 pos = MapPosList[index];
        switch(which)
        {
            case 0: wallPosList.Add(MapPosList[index]); break;
            case 1: toolPosList.Add(MapPosList[index]); break;
            case 2: foodPosList.Add(MapPosList[index]); break;
            case 3: break;
        }
        MapPosList.RemoveAt(index);
        return pos;
    }

    public void RemovePos(Vector3 pos, int which)
    {
        switch (which)
        {
            case 1: toolPosList.Remove(pos); break;
            case 2: foodPosList.Remove(pos); break;
        }
    }

    //取随机游戏物品方法
    private GameObject RandomObject(GameObject[] my_object)
    {
        int index = Random.Range(0, my_object.Length);
        return my_object[index];
    }

    public void InsertPos(Vector3 pos)
    {
        MapPosList.Add(pos);
    }

    public void CreateToolAgain(int which)
    {
        if(which==1)
            GameObject.Instantiate(RandomObject(tool), RandomPos(which), Quaternion.identity).transform.SetParent(Map);
        else if (which == 2)
            GameObject.Instantiate(RandomObject(food), RandomPos(which), Quaternion.identity).transform.SetParent(Map);
    }

    public List<Vector3> WallPosList
    {
        get { return wallPosList; }
    }

    public List<Vector3> ToolPosList
    {
        get { return toolPosList; }
    }

    public List<Vector3> FoodPosList
    {
        get { return foodPosList; }
    }
}
