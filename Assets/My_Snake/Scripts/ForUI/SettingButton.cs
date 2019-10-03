using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour {

    public GameObject[] button;
    private int whichChoose;

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
    }

    public void Choose()
    {
        switch (whichChoose)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
                break;
            case 2:
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
                break;
        }
    }
}
