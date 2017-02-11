using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefManager.GetMasterVolume();
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("Load music level: " + level);
        AudioClip currentClip = levelMusicChangeArray[level];
        if(currentClip)
        {
            audioSource.clip = currentClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
