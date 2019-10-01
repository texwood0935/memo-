using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartChooseMenu : MonoBehaviour {

    public Image chooseMenu;
    public GameObject[] button;
    private int whichChoose;

    // Use this for initialization
    void Start()
    {
        whichChoose = 1;
        Button btn1 = (Button)button[0].GetComponent<Button>();
        Button btn2 = (Button)button[1].GetComponent<Button>();
        Button btn3 = (Button)button[2].GetComponent<Button>();
        Button btn4 = (Button)button[3].GetComponent<Button>();
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
        btn3.onClick.AddListener(delegate ()
        {
            whichChoose = 3;
            Choose();
        });
        btn4.onClick.AddListener(delegate ()
        {
            whichChoose = 4;
            Choose();
        });
    }

    // Update is called once per frame
    void Update()
    {

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
