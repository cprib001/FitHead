using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public Text HighScoreEasy;
    public Text HighScoreMedium;
    public Text HighScoreHard;

    // Use this for initialization
    void Start () {
        //PlayerPrefs.DeleteAll();
        HighScoreEasy.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore easy");
        HighScoreMedium.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore medium");
        HighScoreHard.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore hard");

    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
