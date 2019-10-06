using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpChooseMenu : MonoBehaviour {

    public AudioSource music;
    public Image chooseMenu;
    public Sprite[] chooseSprites;
    public GameObject[] button;
    private int whichChoose;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        whichChoose = 1;
        chooseMenu.sprite = chooseSprites[0];
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
            Choose();
        });
        btn2.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 2;
            Choose();
        });
        btn3.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 3;
            Choose();
        });
        btn4.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 4;
            Choose();
        });
        btn5.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            whichChoose = 5;
            Invoke("Choose", music.clip.length / 2);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Choose()
    {
        switch(whichChoose)
        {
            case 1:
                chooseMenu.sprite = chooseSprites[0];
                break;
            case 2:
                chooseMenu.sprite = chooseSprites[1];
                break;
            case 3:
                chooseMenu.sprite = chooseSprites[2];
                break;
            case 4:
                chooseMenu.sprite = chooseSprites[3];
                break;
            case 5:
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                break;
        }
    }
}
