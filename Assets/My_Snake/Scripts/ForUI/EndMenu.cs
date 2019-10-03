using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {
    public GameObject[] button;
    public int[] scence;
    public Text ScoreText;
    private int whichChoose;

    // Use this for initialization
    void Start()
    {
        whichChoose = 1;
        Button btn1 = (Button)button[0].GetComponent<Button>();
        Button btn2 = (Button)button[1].GetComponent<Button>();
        if(button.Length>=3)
        {
            Button btn3 = (Button)button[2].GetComponent<Button>();
            btn3.onClick.AddListener(delegate ()
            {
                whichChoose = 3;
                Choose();
            });
        }
        btn1.onClick.AddListener(delegate ()
        {
            whichChoose = 1;
            Choose();
        });
        btn2.onClick.AddListener(delegate ()
        {
            whichChoose = 2;
            Choose();
        });
        if (ScoreText!=null)
            ScoreText.text = "" + ScoreRecord.Instance.score;
    }

    public void Choose()
    {
        switch (whichChoose)
        {
            case 1:
                SceneManager.LoadScene(scence[0]);
                break;
            case 2:
                SceneManager.LoadScene(scence[1]);
                break;
            case 3:
                if(scence.Length>=3)
                    SceneManager.LoadScene(scence[2]);
                break;
        }
    }
}
