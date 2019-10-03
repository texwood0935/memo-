using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecord : MonoBehaviour {

    private static ScoreRecord _instance;

    public int score = 0;
    public int length = 0;
    public int speed = 0;
    public Text scoreText;
    public Text lengthText;
    public Text speedText;

    public static ScoreRecord Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        speedText.text = "" + speed;
        scoreText.text = "" + score;
        lengthText.text = "" + length;
    }

    public void UpdateUI(int s,int l)
    {
        score += s;
        length = l;
        scoreText.text = "" + score;
        lengthText.text = "" + length;
    }

    public void UpdateSpeedUI(int s=5)
    {
        speed = s;
        speedText.text = "" + speed;
    }
}
