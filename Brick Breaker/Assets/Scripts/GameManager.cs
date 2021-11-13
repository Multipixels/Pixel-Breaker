using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] bricks;

    // Start is called before the first frame update
    void Start() {
        brickPlacer();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void brickPlacer() {
        for(int i = 0; i < 9; i++) {
            for(int j = 0; j < 5; j++) {

                Vector3 placement = new Vector3(-5f + i*1.25f, 3.5f - j*0.75f);

                Instantiate(bricks[0], placement, transform.rotation);
            }
        }
    }


}
