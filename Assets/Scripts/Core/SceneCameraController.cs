using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SceneCameraController : MonoBehaviour
{
   


    public Transform farBackground, middleBackground;


   

    //private float lastXPos;

    private Vector2 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        //  lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {



        //float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) *.5f;

        //lastXPos = transform.position.x;

        lastPos = transform.position;
    }
}
