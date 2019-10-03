using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {
    public GameObject[] button;
    public int[] scence;
    public Text ScoreText;
    private int whichChoose;

    // Use this for initialization
    void Start()
    {
        whichChoose = 1;
        /*Button[] btn = new Button[button.Length];
        for(int i=0;i<btn.Length;i++)
        {
            btn[i] = (Button)button[i].GetComponent<Button>();
            btn[i].onClick.AddListener(delegate ()
            {
                whichChoose = i+1;
                Choose();
            });
        }*/
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
                UnityEngine.SceneManagement.SceneManager.LoadScene(scence[0]);
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene(scence[1]);
                break;
            case 3:
                if(scence.Length>=3)
                    UnityEngine.SceneManagement.SceneManager.LoadScene(scence[2]);
                break;
        }
    }
}
