using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera cameraInstance;
    private GameObject parent;

	// Use this for initialization
	void Start () {
        parent = GameObject.Find("Defenders");

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        GameObject defender = Button.selectedDefender;
        GameObject newDefender = Instantiate(defender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
        newDefender.transform.parent = parent.transform;
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
}
