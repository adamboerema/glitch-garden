using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

    public float levelSeconds = 10;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("YouWin");
        winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if(timeIsUp && !isEndOfLevel)
        {
            HandleWinCondition();
        }
	}

    void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTaggedObjects()
    {
       GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
       foreach(GameObject taggedObject in gameObjects)
       {
            Destroy(taggedObject);
       }
    }

    void LoadNextLevel ()
    {
        levelManager.LoadNextLevel();
    }
}
