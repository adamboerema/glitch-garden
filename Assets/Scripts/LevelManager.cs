using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNexLevelAfter;

    void Start()
    {
        if (autoLoadNexLevelAfter <= 0) {
            Debug.Log("Level auto load disabled, use positive number in seconds");
        } else
        {
            Invoke("LoadNextLevel", autoLoadNexLevelAfter);
        }
    }

	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}

	public void QuitRequested() {
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
