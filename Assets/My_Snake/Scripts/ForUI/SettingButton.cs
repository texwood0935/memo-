using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour {

    public AudioSource music;
    public GameObject[] button;
    private int whichChoose;

    void Start()
    {
        whichChoose = 1;
        Button btn1 = (Button)button[0].GetComponent<Button>();
        Button btn2 = (Button)button[1].GetComponent<Button>();
        btn1.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            whichChoose = 1;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            Time.timeScale = 1;
            StartCoroutine(Wait(music.clip.length / 4));
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
                Debug.Log("Calling 2");
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
                break;
            case 2:
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
                break;
        }
    }
}
