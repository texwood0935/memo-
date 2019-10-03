using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {

    private List<Transform> bodyList = new List<Transform>();
    private List<Vector3> headOldPos = new List<Vector3>();
    public GameObject bodyPerfabs;
    public float speed = 5.0f;
    public float r = 3.0f;
    public int posLength = 12;
    public int UPposLength = 12;
    public GameObject[] menu;
    public GameObject sheilderCircle;

    private Vector3 headPos;
    private Vector3 mousePos;
    private Vector3 direction;
    private Rigidbody2D rdby;
    private Transform canvas;
    private float ospeed;
    private int oPosLength;
    private bool isUP = false;
    private bool issheilder = false;
    private static bool isRiskDead = false;

    void Awake()
    {
        for(int i=0;i<menu.Length;i++)
            menu[i].SetActive(false);
        isRiskDead = false;
        sheilderCircle.SetActive(false);
    }
    void Start () {
        rdby = gameObject.GetComponent<Rigidbody2D>();
        canvas = GameObject.Find("Snake").transform;
        ospeed = speed;
        oPosLength = posLength;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!isRiskDead)
            Move();
	}

    public static bool IsRiskDead
    {
        get
        {
            return isRiskDead;
        }
    }

    void Grow()
    {
        GameObject body = Instantiate(bodyPerfabs);
        body.transform.SetParent(canvas);
        bodyList.Add(body.transform);
        body.transform.position = transform.position;
    }

    void Follow()
    {
        for(int i=0;i<bodyList.Count;i++)
        {
            bodyList[i].position = headOldPos[(i + 1) * posLength];
        }
    }

    void Move()
    {
        headOldPos.Insert(0, this.gameObject.GetComponent<Transform>().position);
        headPos = Camera.main.WorldToScreenPoint(this.gameObject.GetComponent<Transform>().position);
        mousePos = Input.mousePosition;
        direction = mousePos - headPos;
        if (direction.magnitude>r)
        {
            direction = direction.normalized;
            rdby.velocity = new Vector2(direction.x, direction.y) * speed;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
        Follow();
    }

    void SpeedReset()
    {
        speed = ospeed;
        posLength = oPosLength;
        isUP = false;
        ScoreRecord.Instance.UpdateSpeedUI(5);
    }
    void SheilderReset()
    {
        issheilder = false;
        sheilderCircle.SetActive(false);
    }

    void Die()
    {
        CancelInvoke();
        rdby.velocity = new Vector2(0, 0);
        isRiskDead = true;
        menu[0].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "food")
        {
            Destroy(collision.gameObject);
            ScoreRecord.Instance.UpdateUI(10, bodyList.Count);
            Grow();
            ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "boom")
        {
            Destroy(collision.gameObject);
            if(!issheilder)
            {
                int num = bodyList.Count;
                for (int i = 0; i < num / 2; i++)
                {
                    Destroy(bodyList[bodyList.Count - 1].gameObject);
                    bodyList.Remove(bodyList[bodyList.Count - 1]);
                }
                ScoreRecord.Instance.UpdateUI(-20, bodyList.Count);
            }
            ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "energy")
        {
            Destroy(collision.gameObject);
            if(!isUP)
            {
                isUP = true;
                speed = speed * 1.5f;
                posLength = UPposLength;
                ScoreRecord.Instance.UpdateSpeedUI(8);
                Invoke("SpeedReset", 6.0f);
            }
            ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "mushroom")
        {
            Destroy(collision.gameObject);
            int num = bodyList.Count;
            for (int i = 0; i < num ; i++)
                Grow();
            ScoreRecord.Instance.UpdateUI(20, bodyList.Count);
            ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "poigress")
        {
            Destroy(collision.gameObject);
            if(!issheilder)
            {
                if (bodyList.Count >= 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Destroy(bodyList[bodyList.Count - 1].gameObject);
                        bodyList.Remove(bodyList[bodyList.Count - 1]);
                    }

                }
                else if (bodyList.Count == 1)
                {
                    Destroy(bodyList[bodyList.Count - 1].gameObject);
                    bodyList.Remove(bodyList[bodyList.Count - 1]);
                }
                ScoreRecord.Instance.UpdateUI(-10, bodyList.Count);
            }
            ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "sheild")
        {
            Destroy(collision.gameObject);
            sheilderCircle.SetActive(true);
            issheilder = true;
            Invoke("SheilderReset", 5.0f);
            ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "wall")
        {
            Die();
        }
    }
}
