using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = (Button)this.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
