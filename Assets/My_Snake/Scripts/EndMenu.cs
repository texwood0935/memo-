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
        Button btn1 = (Button)button[0].GetComponent<Button>();
        Button btn2 = (Button)button[1].GetComponent<Button>();
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
        }
    }
}
