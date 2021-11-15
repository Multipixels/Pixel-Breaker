using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] bricks;
    public RectTransform heartIndicator;
    public Text heartText;

    private float timePassed;
    private bool heartShown = false;

    IEnumerator heartCoroutine;

    private int level;

    private int lives;
    private float heartInvulnerability;

    // Start is called before the first frame update
    void Awake() {
        Time.timeScale = 0;

        
    }

    void Start() {
        heartCoroutine = LerpHeart(); 
        levelOne();
        level = 1;

        lives = 3;
    }

    // Update is called once per frame
    void Update() {
        timePassed += Time.deltaTime;

        if(timePassed >= 8 && heartShown == false) {
            heartShown = true;

            StartCoroutine(heartCoroutine);
        }

        if(timePassed >= 10) {
            BrickBehaviour.setSpeed();
        }

        if(timePassed >= 20 && level < 2) {
            print("hi");
            level = 2;
            levelTwo();
        }

        if(heartInvulnerability > 0) {
            heartInvulnerability -= Time.deltaTime;
        }

        if(GameObject.FindGameObjectsWithTag("Ball").Length == 0) {
            Time.timeScale = 0;
        }

        heartText.text = lives + "x";
    }

    IEnumerator LerpHeart() {
        float timePassedLerp = 0f;
        Vector3 startPosition = new Vector3(1097.5f, 465f, 0);
        Vector3 endPosition = new Vector3(822.5f, 465f, 0);

        while(timePassedLerp <= 2) {
            timePassedLerp += Time.deltaTime;
            float normalizedNumber = timePassedLerp / 2f;
            heartIndicator.anchoredPosition = new Vector3(Mathf.Lerp(1097.5f, 822.5f, normalizedNumber), 465f, 0);
            yield return null;
        }

        yield return null;
    }

    public void continueGame(GameObject button) {
        GameObject.Find("Paddle").transform.DetachChildren();
        Destroy(button);
        Time.timeScale = 1;
    }

    void levelOne() {
        for(int i = 0; i < 7; i++) {
            for(int j = 0; j < 5; j++) {

                Vector3 placement = new Vector3(-3.75f + i*1.25f, 1.0f + j*0.75f);

                Instantiate(bricks[0], placement, transform.rotation);
            }
        }
    }

    void levelTwo() {
        for(int i = 0; i < 9; i++) {
            for(int j = 0; j < 5; j++) {

                Vector3 placement = new Vector3(-5f + i*1.25f, 5.5f + j*0.75f);

                Instantiate(bricks[0], placement, transform.rotation);
            }
        }
    }

    public void removeHeart() {
        if(heartInvulnerability <= 0) {
            lives -= 1;
            heartInvulnerability = 2;
        }
    }

}
