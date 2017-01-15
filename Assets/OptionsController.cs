using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit ()
    {
        PlayerPrefManager.SetDifficulty(difficultySlider.value);
        PlayerPrefManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel("01Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2;
    }
}
