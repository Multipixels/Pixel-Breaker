using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] bricks;
    public RectTransform heartIndicator;
    public Text heartText;
    public GameObject restartButton;

    private float timePassed;
    private float levelTimePassed;

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
        timePassed = 0;
        levelTimePassed = 20;
        
        heartCoroutine = LerpHeart(); 
        level = 1;
        levelSummon(level);
        
        lives = 3;
    }

    // Update is called once per frame
    void Update() {
        timePassed += Time.deltaTime;
        levelTimePassed += Time.deltaTime;
        

        if(timePassed >= 8 && heartShown == false) {
            heartShown = true;

            StartCoroutine(heartCoroutine);
        }

        if(timePassed >= 10) {
            BrickBehaviour.setSpeed();
        }

        if(levelTimePassed >= (8.5f / BrickBehaviour.getSpeed() / 2) && BrickBehaviour.getSpeed() != 0) {
            print(level);
            print(levelTimePassed);
            levelTimePassed = 0;
            level++;
            levelSummon(level);
        }

        if(heartInvulnerability > 0) {
            heartInvulnerability -= Time.deltaTime;
        }

        heartText.text = lives + "x";

        if(GameObject.FindGameObjectsWithTag("Ball").Length == 0) {
            lose();
        }
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

    void levelSummon(int levelNumber) {
        switch(levelNumber){
            case 1:
                for(int i = 0; i < 7; i++) {
                    for(int j = 0; j < 5; j++) {
                        Vector3 placement = new Vector3(-3.75f + i*1.25f, 1.0f + j*0.75f);

                        Instantiate(bricks[0], placement, transform.rotation);
                    }
                }
                break;
            case 2:
                for(int i = 0; i < 9; i++) {
                    for(int j = 0; j < 5; j++) {
                        Vector3 placement = new Vector3(-5f + i*1.25f, 5.5f + j*0.75f);

                        Instantiate(bricks[0], placement, transform.rotation);
                    }
                }
                break;

            case 3:
                for(int i = 0; i < 9; i++) {
                    for(int j = 0; j < 5; j++) {
                        Vector3 placement = new Vector3(-5f + i*1.25f, 5.5f + j*0.75f);

                        Instantiate(bricks[0], placement, transform.rotation);
                    }
                }
                break;

            case 4:
                for(int i = 0; i < 5; i++) {
                    for(int j = 0; j < (i*2 + 1); j++) {
                        Vector3 placement = new Vector3((-1.25f*i) + j*1.25f, 5.5f + i*0.75f);

                        Instantiate(bricks[0], placement, transform.rotation);
                    }
                }
                break;
            
            case 5:
                for(int i = 0; i < 5; i++) {
                    for(int j = 0; j < ((4-i)*2 + 1); j++) {
                        Vector3 placement = new Vector3((-1.25f*(4-i)) + j*1.25f, 5.5f + i*0.75f);

                        Instantiate(bricks[0], placement, transform.rotation);
                    }
                }
                break;
        }
    }

    public void removeHeart() {
        if(heartInvulnerability <= 0) {
            lives -= 1;
            heartInvulnerability = 2;
        }

        if(lives == 0) {
            lose();
        }
    }

    public void lose() {
        Time.timeScale = 0;
        restartButton.SetActive(true);
    }

    public void restart() {
        SceneManager.LoadScene(0);
    }

}
