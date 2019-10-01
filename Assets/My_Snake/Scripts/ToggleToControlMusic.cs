using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleToControlMusic : MonoBehaviour {

    public GameObject obj;
    private Toggle toggle;
    private AudioSource ourmusic = ForMusicUnchange.maudio;
    private bool isClick=true;

    // Use this for initialization
    void Awake()
    {
        toggle = (Toggle)obj.GetComponent<Toggle>();
        isClick = AllData.Instance.MusicToggle;
        toggle.isOn = AllData.Instance.MusicToggle;
    }
    void Start () {
        isClick = AllData.Instance.MusicToggle;
        toggle.onValueChanged.AddListener((bool value) => OnToggleClick(toggle,value));
	}
	
	public void OnToggleClick(Toggle toggle ,bool value)
    {
        if(isClick)
        {
            isClick = !isClick;
            ourmusic.Stop();
            AllData.Instance.MusicToggle = isClick;
        }
        else
        {
            isClick = !isClick;
            ourmusic.Play();
            AllData.Instance.MusicToggle = isClick;
        }
        Debug.Log("You Click Me!");
    }
}
