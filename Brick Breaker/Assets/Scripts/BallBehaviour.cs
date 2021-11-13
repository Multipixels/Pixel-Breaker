using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallBehaviour : MonoBehaviour
{

    private float speed;
    private Vector3 movementVector;

    private Rigidbody2D rb;

    private bool hasCollided;

    void Start(){
        movementVector = new Vector3(0, -1, 0);
        speed = 8;

        rb = GetComponent<Rigidbody2D>();

        hasCollided = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //transform.position += movementVector * Time.deltaTime * speed;
        rb.velocity = movementVector * speed;

        hasCollided = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(hasCollided == false) {
            if(collision.gameObject.tag == "Paddle") {
                float collisionContactPoint = collision.GetContact(0).point[0];
                Vector2 normalVector = collision.GetContact(0).normal;

                print(collisionContactPoint);

                collisionContactPoint += -collision.gameObject.transform.position.x;

                float angleMultiplier = collisionContactPoint / (collision.gameObject.transform.localScale.x / 2);
                float angle = angleMultiplier * (Mathf.PI / 4);

                Vector2 newMovementCollider = new Vector2(0, 0);

                if(normalVector[0] == 0) {
                    newMovementCollider = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle) * normalVector[1]);
                } else {
                    newMovementCollider = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
                }

                movementVector = newMovementCollider;
                
            } else {

                Vector2 normalVector = collision.GetContact(0).normal;
                print(normalVector);
                print(movementVector);
                if(Math.Abs(normalVector[0]) != 1) {
                    movementVector = new Vector2(movementVector[0], -movementVector[1]);
                    print("bot/top");
                } else {
                    movementVector = new Vector2(-movementVector[0], movementVector[1]);
                    print("side");
                }

                print(movementVector);

                if(collision.gameObject.tag == "Brick") {
                    Destroy(collision.gameObject);
                }
            }

            hasCollided = true;
        }
        
    }
}
