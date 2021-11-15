using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    private float screenBoundryX;
    private float paddleSize;

    void Start() {
        paddleSize = transform.localScale.x;
        screenBoundryX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0))[0];
    }

    void LateUpdate() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 position = transform.position;
        position[0] = mousePos.x;


        if(position[0] > screenBoundryX - (paddleSize / 2) - 0.2f) {
            position[0] = screenBoundryX - (paddleSize / 2) - 0.2f;
        } else if(position[0] < -screenBoundryX + (paddleSize / 2) + 0.2f) {
            position[0] = -screenBoundryX + (paddleSize / 2) + 0.2f;
        }


        transform.position = position;

    }



}
