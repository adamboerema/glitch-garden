using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour
{

    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        if (musicManager)
        {
            float volume = PlayerPrefManager.GetMasterVolume();
            musicManager.ChangeVolume(volume);
        }
        else
        {
            Debug.Log("No music manager found");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
