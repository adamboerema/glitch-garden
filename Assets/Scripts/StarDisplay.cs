using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public static int starCount = 100;
    private Text starDisplay;

    public enum Status { SUCCESS, FAILURE };

    void Start ()
    {
        starDisplay = GetComponent<Text>();
        SetStarDisplay(starCount);
    }

    public void AddStars(int amount)
    {
        starCount += amount;
        SetStarDisplay(starCount);
    }
	
    public Status UseStars(int amount)
    {
        if(starCount >= amount)
        {
            starCount -= amount;
            SetStarDisplay(starCount);
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void SetStarDisplay(int amount)
    {
        starDisplay.text = amount.ToString();
    }
}
