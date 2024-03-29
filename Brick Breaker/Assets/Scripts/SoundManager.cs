using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {
    
    public static Dictionary<AudioClip, float> timerDict;

    public enum Sound {
        HitBrick,
        HitWall,
        LoseBall,
        LoseLife,
        LoseGame
    }

    public enum Music {
        BipBop,
        Brink,
        SparkleStars
    }

    public static void playSound(Sound sound) {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound) {
        foreach(AssetManager.SoundAudioClip soundAC in AssetManager.i.sounds) {
            if(soundAC.sound == sound) {
                return soundAC.audioClip;
            }
        }

        return null;
    }

    public static AudioClip GetMusic(Music music) {
        foreach(AssetManager.MusicAudioClip musicAC in AssetManager.i.musicClips) {
            if(musicAC.music == music) {
                return musicAC.audioClip;
            }
        }

        return null;
    }

}
