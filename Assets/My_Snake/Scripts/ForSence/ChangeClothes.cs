using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeClothes : MonoBehaviour {

    public Button[] clothes;
    public AudioSource music;

	// Use this for initialization
	void Start () {
        clothes[0].onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            AllData.Instance.whichClothes = 0;
            Invoke("ChangScence", music.clip.length / 2);
        });
        clothes[1].onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            AllData.Instance.whichClothes = 1;
            Invoke("ChangScence", music.clip.length / 2);
        });
        clothes[2].onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            AllData.Instance.whichClothes = 2;
            Invoke("ChangScence", music.clip.length / 2);
        });
        clothes[3].onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            AllData.Instance.whichClothes = 3;
            Invoke("ChangScence", music.clip.length / 2);
        });
    }

    void ChangScence()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
