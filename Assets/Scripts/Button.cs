using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject defenderPreab;
    public static GameObject selectedDefender;
    private Text costText;
    private Button[] buttonArray;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogWarning(name + "has no cost text");
        }
        costText.text = defenderPreab.GetComponent<Defender>().starCost.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}


    void OnMouseDown()
    {
        foreach(Button btn in buttonArray)
        {
            btn.GetComponent<SpriteRenderer>().color = Color.black;
        }
    
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPreab;
    }
}
