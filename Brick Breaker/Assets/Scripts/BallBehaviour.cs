using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class BallBehaviour : MonoBehaviour
{

    private float speed;
    private Vector3 movementVector;

    private Rigidbody2D rb;

    private bool hasCollided;

    void Start() {
        float tempAngle = Random.Range(Mathf.PI / 4, 3 * Mathf.PI / 4);
        movementVector = new Vector2(Mathf.Cos(tempAngle), Mathf.Sin(tempAngle));
        speed = 8;

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = movementVector * speed;

        hasCollided = false;
    }

    // Update is called once per frame
    void FixedUpdate() {       
        hasCollided = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "Kill") {
            Destroy(gameObject);
        }

        if(hasCollided == false) {
            if(collision.gameObject.tag == "Paddle") {
                float collisionContactPoint = collision.GetContact(0).point[0];
                Vector2 normalVector = collision.GetContact(0).normal;

                collisionContactPoint += -collision.gameObject.transform.position.x;

                float angleMultiplier = collisionContactPoint / (collision.gameObject.transform.localScale.x / 2);
                if(angleMultiplier >= 0) {
                    angleMultiplier = ExtensionMethods.Remap(angleMultiplier, 0, 1, 0.5f, 1.25f);
                } else {
                    angleMultiplier = ExtensionMethods.Remap(angleMultiplier, -1, 0, -1.25f, -0.5f);
                }
                
                float angle = angleMultiplier * (Mathf.PI / 4);

                Vector2 newMovementCollider = new Vector2(0, 0);

                if(normalVector[0] == 0) {
                    newMovementCollider = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle) * normalVector[1]);
                } else {
                    newMovementCollider = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
                }

                movementVector = newMovementCollider;
                changeVelocity(movementVector);
                
            }/* else {

                Vector2 normalVector = collision.GetContact(0).normal;
                if(Mathf.Abs(normalVector[0]) != 1) {
                    movementVector = new Vector2(movementVector[0], -movementVector[1]);
                } else {
                    movementVector = new Vector2(-movementVector[0], movementVector[1]);
                }

                //if(collision.gameObject.tag == "Brick") {
                //    Destroy(collision.gameObject);
                //}*/
            //}

            hasCollided = true;
        }
        
        void changeVelocity(Vector3 velocityChange) {
            rb.velocity = velocityChange * speed;
        }
    }
}
