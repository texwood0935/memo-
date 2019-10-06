using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllData : MonoBehaviour {

    public static AllData _instance = new AllData();
    public float MusicValue=1;
    public bool MusicToggle=true;
    public float MusicEffectValue = 1;
    public bool MusicEffectToggle = true;
    public int whichClothes=0;

    public static AllData Instance
    {
        get
        {
            return _instance;
        }
    }
}
