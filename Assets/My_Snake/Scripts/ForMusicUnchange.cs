﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForMusicUnchange : MonoBehaviour {

    public GameObject objPerfabMusic;
    private GameObject musicInstant = null;
    public static  AudioSource maudio=null;

    // Use this for initialization
    void Start () {
        musicInstant = GameObject.FindGameObjectWithTag("sound");
        if (musicInstant == null)
        {
            musicInstant = (GameObject)Instantiate(objPerfabMusic);
            
        }
        if(maudio==null)
            maudio = (AudioSource)musicInstant.GetComponent<AudioSource>();
        maudio.volume = AllData.Instance.MusicValue;
    }
    void Update()
    {
    }
}
