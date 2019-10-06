using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRiskMap : MonoBehaviour {

    public GameObject[] wall;
    public GameObject[] tool;
    public GameObject snakehead;
    public float yMin = 10;
    public float xMin = 10;
    public float yMax = 10;
    public float xMax = 10;
    public float z = 10;
    public float step = 0.1f;
    public int wallNum = 10;
    public int toolNum = 10;

    private Transform Map;
    private List<Vector3> MapPosList = new List<Vector3>();
    private List<Vector3> ToolPosList = new List<Vector3>();
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
        //创建障碍物
        CreateObject(wallNum, wall);

        //创建食物
        CreateObject(toolNum, tool);
        snakehead.transform.position = RandomPos();
    }


    //游戏物体实力化方法
    private void CreateObject(int num, GameObject[] my_object)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject.Instantiate(RandomObject(my_object), RandomPos(), Quaternion.identity).transform.SetParent(Map);
        }
    }

    //取随机位置方法
    private Vector3 RandomPos()
    {
        int index = Random.Range(0, MapPosList.Count);
        Vector3 pos = MapPosList[index];
        MapPosList.RemoveAt(index);
        return pos;
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

    public void CreateToolAgain()
    {
        GameObject.Instantiate(RandomObject(tool), RandomPos(), Quaternion.identity).transform.SetParent(Map);
    }
}
