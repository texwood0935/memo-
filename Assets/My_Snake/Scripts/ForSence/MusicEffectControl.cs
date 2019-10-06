using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicEffectControl : MonoBehaviour {

    public AudioSource music;
    public GameObject obj;
    public Slider sd;
    private Toggle toggle;
    private bool isClick = true;

    // Use this for initialization
    void Awake()
    {
        toggle = (Toggle)obj.GetComponent<Toggle>();
        isClick = AllData.Instance.MusicToggle;
        toggle.isOn = AllData.Instance.MusicToggle;
    }
    void Start()
    {
        isClick = AllData.Instance.MusicEffectToggle;
        toggle.onValueChanged.AddListener((bool value) => OnToggleClick(toggle, value));
        sd.value = AllData.Instance.MusicEffectValue;
    }

    public void OnToggleClick(Toggle toggle, bool value)
    {
        music.volume = AllData.Instance.MusicEffectValue;
        if (AllData.Instance.MusicEffectToggle)
            music.Play();
        if (isClick)
        {
            isClick = !isClick;
            AllData.Instance.MusicEffectToggle = isClick;
        }
        else
        {
            isClick = !isClick;
            AllData.Instance.MusicEffectToggle = isClick;
        }
    }
    public void SliderMove()
    {
        AllData.Instance.MusicEffectValue = sd.value;
    }
}
