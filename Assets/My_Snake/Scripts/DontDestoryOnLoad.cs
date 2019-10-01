using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryOnLoad : MonoBehaviour {

    static DontDestoryOnLoad _instant;

    // Use this for initialization
    void Start()
    {
        
    }

    void Awake()
    {
       if(_instant==null)
        {
            _instant = this;
            DontDestroyOnLoad(this);
        }
       else if(this!=_instant)
        {
            Destroy(gameObject);
        }
    }
}
