using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject snakeHead;

    private void LateUpdate()
    {
        Vector3 vec = snakeHead.transform.position;
        transform.position = new Vector3(vec.x, vec.y, -5);
    }
}
