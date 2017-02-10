using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera cameraInstance;
    private GameObject parent;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
	}

    void OnMouseDown()
    {
        GameObject defender = Button.selectedDefender;
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);

        Debug.Log(defender.GetComponent<Defender>().starCost);
        int defenderCost = defender.GetComponent<Defender>().starCost;

        Debug.Log(starDisplay);
        if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        } else
        {
            Debug.Log("Can not afford defender");
        }
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float roundedX = Mathf.RoundToInt(rawWorldPos.x);
        float roundedY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(roundedX, roundedY);
    }

    Vector2 CalculateWorldPointOfMouseClick ()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 conversionTrip = new Vector3(mouseX, mouseY, distanceFromCamera);
        return cameraInstance.ScreenToWorldPoint(conversionTrip);
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        GameObject newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        newDefender.transform.parent = parent.transform;
    }
}
