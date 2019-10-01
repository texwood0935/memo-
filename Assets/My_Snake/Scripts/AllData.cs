using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllData : MonoBehaviour {

    public static AllData Instance = new AllData();
    public float MusicValue=1;
    public bool MusicToggle=true;

	void Start () {
        //DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
