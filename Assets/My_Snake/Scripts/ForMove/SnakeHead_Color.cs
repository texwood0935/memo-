using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead_Color : MonoBehaviour {

    private List<Transform> bodyList = new List<Transform>();
    private List<Vector3> headOldPos = new List<Vector3>();
    public GameObject bodyPerfabs;
    public float speed = 5.0f;
    public float r = 3.0f;
    public float xoffset = 3.0f;
    public int posLength = 12;
    public GameObject[] menu;

    private Vector3 headPos;
    private Vector3 mousePos;
    private Vector3 direction;
    private Vector2 d;
    private Vector2 d2;
    private Rigidbody2D rdby;
    private Transform canvas;
    private static bool isRiskDead = false;
    private SpriteRenderer SRsh;
    private Color color;
    private float score;

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
        color = new Color32(255, 255, 255, 255);
        SRsh = this.gameObject.GetComponent<SpriteRenderer>();
        score = Time.time;
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
        body.GetComponent<SpriteRenderer>().color = color;
        body.transform.position = transform.position;
    }

    void Follow()
    {
        int j = bodyList.Count - 1;
        for (int i = 0; i < bodyList.Count; i++, j--)
        {
            bodyList[j].position = new Vector3(xoffset * (i + 1) + headOldPos[(i + 1) * posLength].x, headOldPos[(i + 1) * posLength].y);    //headOldPos[(i + 1) * posLength]
        }
    }

    void Move()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
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
        if (bodyList.Count * posLength + 1 < headOldPos.Count)
            Grow();
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

    public void RemoveBody(GameObject sb)
    {
        bodyList.Remove(sb.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "color")
        {
            if(collision.GetComponent<SpriteRenderer>().color!=color)
            {
                ScoreRecord.Instance.UpdateUI((int)((Time.time - score)), bodyList.Count);
                Die();
            }
        }
        else if(collision.tag=="colorline")
        {
            SpriteRenderer collisionSR = collision.gameObject.GetComponent<SpriteRenderer>();
            SRsh.color = collisionSR.color;
            color = collisionSR.color;
        }
    }
}
