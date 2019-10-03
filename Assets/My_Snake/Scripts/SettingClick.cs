using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingClick : MonoBehaviour {

    public GameObject settingMenu;
    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            settingMenu.SetActive(true);
            Time.timeScale = 0;
        });
    }

}
