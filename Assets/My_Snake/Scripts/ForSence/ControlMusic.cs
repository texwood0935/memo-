using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMusic : MonoBehaviour {

    private AudioSource asound=ForMusicUnchange.maudio;
    public Slider sd;

	// Use this for initialization
	void Start () {
        asound = ForMusicUnchange.maudio;
        sd.value = AllData.Instance.MusicValue;
        asound.volume = sd.value;
    }
    public void ControlSound()
    {
        asound.volume = sd.value;
        AllData.Instance.MusicValue = sd.value;
    }
}
