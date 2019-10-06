using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChoose : MonoBehaviour {
    public AudioSource music;
    public GameObject[] button;
    private int whichChoose;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        whichChoose = 1;
        Button btn1 = (Button)button[0].GetComponent<Button>();
        Button btn2 = (Button)button[1].GetComponent<Button>();
        Button btn3 = (Button)button[2].GetComponent<Button>();
        Button btn4 = (Button)button[3].GetComponent<Button>();
        Button btn5 = (Button)button[4].GetComponent<Button>();
        btn1.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 1;
            Invoke("Choose", music.clip.length/2);
        });
        btn2.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 2;
            Invoke("Choose", music.clip.length/2);
        });
        btn3.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 3;
            Invoke("Choose", music.clip.length/2);
        });
        btn4.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 4;
            Invoke("Choose", music.clip.length/2);
        });
        btn5.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 5;
            Invoke("Choose", music.clip.length/2);
        });
    }
    public void Choose()
    {
        switch (whichChoose)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(8);
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(9);
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(10);
                break;
            case 4:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(11);
                break;
            case 5:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
                break;
        }
    }
}
