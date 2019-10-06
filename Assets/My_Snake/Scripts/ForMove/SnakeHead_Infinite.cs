using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead_Infinite : MonoBehaviour {

    private List<Transform> bodyList = new List<Transform>();
    private List<Vector3> headOldPos = new List<Vector3>();
    public GameObject bodyPerfabs;
    public float speed = 5.0f;
    public float r = 3.0f;
    public float xoffset = 3.0f;
    public int posLength = 12;
    public GameObject[] menu;
    public AudioSource[] music;

    private Vector3 headPos;
    private Vector3 mousePos;
    private Vector3 direction;
    private Vector2 d;
    private Vector2 d2;
    private Rigidbody2D rdby;
    private Transform canvas;
    private static bool isRiskDead = false;

    public int GetBodyLength()
    {
        return bodyList.Count;
    }

    void Awake()
    {
        for (int i = 0; i < menu.Length; i++)
            menu[i].SetActive(false);
        isRiskDead = false;
    }
    void Start()
    {
        Time.timeScale = 1;
        rdby = gameObject.GetComponent<Rigidbody2D>();
        canvas = GameObject.Find("Snake").transform;
        isRiskDead = false;
        d2 = d = new Vector2(1, 0);
        for (int i = 0; i < 5; i++)
        {
            GameObject body = Instantiate(bodyPerfabs);
            body.transform.SetParent(canvas);
            bodyList.Add(body.transform);
            body.transform.position = new Vector3(xoffset * (i + 1) + transform.position.x, transform.position.y);
        }
        ScoreRecord.Instance.UpdateUI(0, bodyList.Count);
    }

    void FixedUpdate()
    {
        if (!isRiskDead)
            Move();
        else
        {
            Quaternion q = Quaternion.identity;
            q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d2.x, d2.y, 0));
            gameObject.transform.rotation = q;
        }
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
        for (int i = 0; i < bodyList.Count; i++)
        {
            bodyList[i].position = new Vector3(xoffset * (i+1)+headOldPos[(i + 1) * posLength].x, headOldPos[(i + 1) * posLength].y);    //headOldPos[(i + 1) * posLength]
        }
    }

    void Move()
    {
        headOldPos.Insert(0, this.gameObject.GetComponent<Transform>().position);
        headPos = Camera.main.WorldToScreenPoint(this.gameObject.GetComponent<Transform>().position);
        mousePos = Input.mousePosition;
        direction = mousePos - headPos;
        d = new Vector2(direction.x, direction.y);
        if (d.magnitude > r)
        {
            d = d.normalized;
            d2 = d;
            rdby.velocity = new Vector2(0, d.y) * speed;
            Quaternion q = Quaternion.identity;
            q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d.x, d.y, 0));
            gameObject.transform.rotation = q;
        }
        else
        {
            rdby.velocity = new Vector2(0, d2.y) * speed;
            Quaternion q = Quaternion.identity;
            q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d2.x, d2.y, 0));
            gameObject.transform.rotation = q;
        }
        Follow();
    }

    void Die()
    {
        CancelInvoke();
        Time.timeScale = 0;
        rdby.velocity = new Vector2(0, 0);
        isRiskDead = true;
        menu[0].SetActive(true);
        Quaternion q = Quaternion.identity;
        q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d2.x, d2.y, 0));
        gameObject.transform.rotation = q;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            music[0].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[0].Play();
            NumberUP number = collision.gameObject.GetComponent<NumberUP>();
            int num = number.Value;
            for (int i = 0; i < num; i++)
                Grow();
            ScoreRecord.Instance.UpdateUI(10 * num, bodyList.Count);
            Destroy(collision.gameObject);
            if (ToolPool.Instance != null)
                ToolPool.Instance.CreateTool();
        }
        else if (collision.tag == "dia")
        {
            int num = collision.gameObject.GetComponent<NumberUP>().Value;
            if(bodyList.Count<num)
                Die();
            else
            {
                music[1].volume = AllData.Instance.MusicEffectValue;
                if (AllData.Instance.MusicEffectToggle)
                    music[1].Play();
                Destroy(collision.gameObject);
                for (int i = 0; i < num; i++)
                {
                    Destroy(bodyList[bodyList.Count - 1].gameObject);
                    bodyList.Remove(bodyList[bodyList.Count - 1]);
                }
                ScoreRecord.Instance.UpdateUI(5 * num, bodyList.Count);
            }
        }
    }
}
