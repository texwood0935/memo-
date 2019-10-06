using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEffectPlay : MonoBehaviour {
    public AudioSource musice;

    public void PlayMusic()
    {
        if(AllData.Instance.MusicEffectToggle)
        {
            //musice.volume = AllData.Instance.MusicEffectValue;
            musice.Play();
        }
    }
}
