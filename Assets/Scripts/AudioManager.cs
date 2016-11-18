using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour{

    //Variables

    public static AudioManager audioManager;
    public AudioSource audioSource;

    //Sound variables

    public AudioClip BGM;

    // Use this for initialization
    //On Startup
    void Awake() {

        PlayAudio(BGM);
        audioManager = this;
    }

    //Play one instance
    public void PlayAudio(AudioClip soundEffect) {

        audioSource.PlayOneShot(soundEffect);
    }
}