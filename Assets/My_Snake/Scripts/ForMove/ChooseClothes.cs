using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseClothes : MonoBehaviour {

    public Sprite[] wardrobe;
    public SpriteRenderer who;

    void Start()
    {
        who.sprite = wardrobe[AllData.Instance.whichClothes];
    }
}
