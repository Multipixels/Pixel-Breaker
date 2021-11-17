using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public Sprite[] setOfSprites;
    public Sprite[] setOfPowers;
    public GameObject powerSprite;
    public GameObject ballPower;

    private static float speed;
    
    int ballType = 0;

    private GameManager gm;

    void Start() {
        gm = FindObjectOfType<GameManager>();
        GetComponent<SpriteRenderer>().sprite = setOfSprites[Random.Range(0, 3)];

        int ballTypeRandom = Random.Range(0, 100);
        if(ballTypeRandom == 0) {
            ballType = 1;
            powerSprite.SetActive(true);
            powerSprite.GetComponent<SpriteRenderer>().sprite = setOfPowers[0];
        }
    }

    void Update() {
        transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);

        if(transform.position.y <= -3.5f) {
            gm.removeHeart();
            Destroy(gameObject);
        }
    }

    public static void setSpeed() {
        speed = 0.15f;        
    }

    public static float getSpeed() {
        return speed;
    }

    void OnCollisionEnter2D() {
        GetComponent<BoxCollider2D>().enabled = false;
        if(ballType == 1) {
            Instantiate(ballPower, transform.position, transform.rotation);
        }
        
        Destroy(gameObject);
        
    }
}
