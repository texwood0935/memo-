using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterWardrobe : MonoBehaviour {

    public AudioSource music;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        Button btn = (Button)this.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            music.volume = AllData.Instance.MusicEffectValue;
            if (AllData.Instance.MusicEffectToggle)
                music.Play();
            Invoke("ChangScence", music.clip.length / 4);
        });
    }

    void ChangScence()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(12);
    }
}
