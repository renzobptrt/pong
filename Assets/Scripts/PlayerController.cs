using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //World Mouse Position
    Vector3 mousePos;

    void Start()
    {

    }

    public void Init()
    {
        Vector2 pos = Vector2.zero;
        pos = new Vector2(SetGameScene.bottonLeft.x + 1f, 0);
        //Update the position
        transform.position = pos;
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x,
                                        Mathf.Clamp(mousePos.y, -3.8f, 3.8f),
                                        transform.position.z);
    }
}
