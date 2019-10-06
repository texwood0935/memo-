using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartChooseMenu : MonoBehaviour {

    public Image chooseMenu;
    public GameObject[] button;
    public AudioSource music;
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
    }
    public void Choose()
    {
        switch (whichChoose)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                break;
            case 4:
                Application.Quit();
                break;
        }
    }
}
