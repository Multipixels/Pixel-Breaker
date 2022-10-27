using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource audioSource;

    private static MusicManager _i;

    public static MusicManager i {
        get {
            if(_i == null) _i = Instantiate(Resources.Load<MusicManager>("MusicManager"));
            return _i;
        }
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.volume = 0.4f;
        audioSource.clip = SoundManager.GetMusic(SoundManager.Music.SparkleStars);
    }

    public void startSparkle() {
        audioSource.clip = SoundManager.GetMusic(SoundManager.Music.SparkleStars);
        audioSource.Play();
    }

    public void startBip() {
        audioSource.clip = SoundManager.GetMusic(SoundManager.Music.BipBop);
        audioSource.Play();
    }

    public void startBrink() {
        audioSource.clip = SoundManager.GetMusic(SoundManager.Music.Brink);
        audioSource.Play();
    }
}
