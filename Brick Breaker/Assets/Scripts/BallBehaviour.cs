using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallBehaviour : MonoBehaviour
{

    private float speed;
    private Vector3 movementVector;

    private Rigidbody2D rb;

    void Start(){
        movementVector = new Vector3(0, -1, 0);
        speed = 8;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //transform.position += movementVector * Time.deltaTime * speed;
        rb.velocity = movementVector * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "Paddle") {
            float collisionContactPoint = collision.GetContact(0).point[0];
            Vector2 normalVector = collision.GetContact(0).normal;

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
            print(collision.GetContact(0).normal);
        } else {

            Vector2 normalVector = collision.GetContact(0).normal;
            print(normalVector);
            print(movementVector);
            if(normalVector[0] == 0) {
                movementVector = new Vector2(movementVector[0], -movementVector[1]);
            } else {
                print("works)");
                movementVector = new Vector2(-movementVector[0], movementVector[1]);
                print(movementVector);
            }
        }

        
    }
}
