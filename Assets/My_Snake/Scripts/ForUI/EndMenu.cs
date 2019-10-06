using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {
    public AudioSource music;
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
                music.volume = AllData.Instance.MusicEffectValue;
                if (AllData.Instance.MusicEffectToggle)
                    music.Play();
                whichChoose = 3;
                Time.timeScale = 1;
                StartCoroutine(Wait(music.clip.length/4));
            });
        }
        btn1.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 1;
            Time.timeScale = 1;
            Invoke("Choose", music.clip.length / 4);
        });
        btn2.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 2;
            Time.timeScale = 1;
            Choose();
        });
        if (ScoreText!=null)
            ScoreText.text = "" + ScoreRecord.Instance.score;
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);//运行到这，暂停t秒

        //t秒后，继续运行下面代码
        Choose();
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
