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
    public AudioSource[] music;

    private Vector3 headPos;
    private Vector3 mousePos;
    private Vector3 direction;
    private Vector2 d;
    private Vector2 d2;
    private Rigidbody2D rdby;
    private Transform canvas;
    private float ospeed;
    private int oPosLength;
    private bool isUP = false;
    private bool issheilder = false;
    private bool isHaveAKey = false;
    private static bool isRiskDead = false;

    void Awake()
    {
        for(int i=0;i<menu.Length;i++)
            menu[i].SetActive(false);
        isRiskDead = false;
        isHaveAKey = false;
        sheilderCircle.SetActive(false);
    }
    void Start () {
        Time.timeScale = 1;
        rdby = gameObject.GetComponent<Rigidbody2D>();
        canvas = GameObject.Find("Snake").transform;
        ospeed = speed;
        oPosLength = posLength;
        isRiskDead = false;
        d2 = d = new Vector2(1, 0);
        switch (this.gameObject.scene.name)
        {
            case "Level1": ScoreRecord.Instance.UpdateLevelUI(1); break;
            case "Level2": ScoreRecord.Instance.UpdateLevelUI(2); break;
            case "Level3": ScoreRecord.Instance.UpdateLevelUI(3); break;
            case "Level4": ScoreRecord.Instance.UpdateLevelUI(4); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate () {
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
        d = new Vector2(direction.x, direction.y);
        if (d.magnitude>r)
        {
            d = d.normalized;
            d2 = d;
            rdby.velocity = new Vector2(d.x, d.y) * speed;
            Quaternion q = Quaternion.identity;
            q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d.x, d.y, 0));
            gameObject.transform.rotation = q;
        }
        else
        {
            rdby.velocity = new Vector2(d2.x, d2.y) * speed;
            Quaternion q = Quaternion.identity;
            q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d2.x, d2.y, 0));
            gameObject.transform.rotation = q;
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
        Quaternion q = Quaternion.identity;
        q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d2.x, d2.y, 0));
        gameObject.transform.rotation = q;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "food")
        {
            music[0].volume = AllData.Instance.MusicEffectValue;
            if(AllData.Instance.MusicEffectToggle)
                music[0].Play();
            ScoreRecord.Instance.UpdateUI(10, bodyList.Count);
            Grow();
            if(CreateRiskMap.Instance!=null)
            {
                CreateRiskMap.Instance.CreateToolAgain();
                CreateRiskMap.Instance.InsertPos(collision.transform.position);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "boom")
        {
            music[1].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[1].Play();
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
            if (CreateRiskMap.Instance != null)
            {
                CreateRiskMap.Instance.CreateToolAgain();
                CreateRiskMap.Instance.InsertPos(collision.transform.position);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "energy")
        {
            music[2].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[2].Play(); 
            if(!isUP)
            {
                isUP = true;
                speed = speed * 1.5f;
                posLength = UPposLength;
                ScoreRecord.Instance.UpdateSpeedUI(8);
                Invoke("SpeedReset", 6.0f);
            }
            if (CreateRiskMap.Instance != null)
            {
                CreateRiskMap.Instance.CreateToolAgain();
                CreateRiskMap.Instance.InsertPos(collision.transform.position);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "mushroom")
        {
            music[3].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[3].Play();
            int num = bodyList.Count;
            for (int i = 0; i < num ; i++)
                Grow();
            ScoreRecord.Instance.UpdateUI(20, bodyList.Count);
            if (CreateRiskMap.Instance != null)
            {
                CreateRiskMap.Instance.CreateToolAgain();
                CreateRiskMap.Instance.InsertPos(collision.transform.position);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "poigress")
        {
            music[4].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[4].Play();
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
            if (CreateRiskMap.Instance != null)
            {
                CreateRiskMap.Instance.CreateToolAgain();
                CreateRiskMap.Instance.InsertPos(collision.transform.position);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "sheild")
        {
            music[5].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[5].Play();
            sheilderCircle.SetActive(true);
            issheilder = true;
            Invoke("SheilderReset", 5.0f);
            if (CreateRiskMap.Instance != null)
            {
                CreateRiskMap.Instance.CreateToolAgain();
                CreateRiskMap.Instance.InsertPos(collision.transform.position);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "key")
        {
            Destroy(collision.gameObject);
            isHaveAKey = true;
        }
        else if (collision.tag == "door")
        {
            music[6].volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music[6].Play();
            if (isHaveAKey)
                Destroy(collision.gameObject);
        }
        else if (collision.tag == "exit")
        {
            CancelInvoke();
            rdby.velocity = new Vector2(0, 0);
            isRiskDead = true;
            Quaternion q = Quaternion.identity;
            q.SetLookRotation(new Vector3(0, 0, -1), new Vector3(d2.x, d2.y, 0));
            gameObject.transform.rotation = q;
            if (menu.Length>=3)
                menu[2].SetActive(true);
        }
        else if (collision.tag == "wall"|| collision.tag == "monster")
        {
            Die();
        }
    }
}
