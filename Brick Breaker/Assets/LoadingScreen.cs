using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    void Start() {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync(1);
    }
}

