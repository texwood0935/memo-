using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingClick : MonoBehaviour {

    public AudioSource music;
    public GameObject settingMenu;
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            settingMenu.SetActive(true);
            Time.timeScale = 0;
        });
    }

}
