using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBody : MonoBehaviour {

    public SnakeHead_Color shc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="snakebody")
        {
            shc.RemoveBody(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
