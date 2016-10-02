using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public int hitCounter = 3;
    public bool isPlaying = true;
    public AudioSource failSound;
    public AudioSource musicEasy;
    public AudioSource musicMedium;
    public AudioSource musicHard;
    public AudioSource failMusic;
    public bool hit3 = false;
    public GameObject mainMenuCube;
    public GameObject mainMenuText;
    public GameObject restartCube;
    public GameObject restartText;
    public GameObject mainMenuTitle;
    public GameObject restartTitle;
    public GameObject timerText;
    public GameObject hitsText;

    public bool isPaused = false;

    public float timer = 0;

    public GameObject theGenerator;

    // Use this for initialization
    void Start () {

	    if(PlayerPrefs.GetString("Level Difficulty") == "easy")
        {
            theGenerator.GetComponent<ObjectSpawner>().enabled = true;
            theGenerator.GetComponent<ObjectFlatSpawner>().enabled = false;
            theGenerator.GetComponent<ObjectTallSpawner>().enabled = false;
            musicEasy.Play();
        }
        else if (PlayerPrefs.GetString("Level Difficulty") == "medium")
        {
            theGenerator.GetComponent<ObjectSpawner>().enabled = true;
            theGenerator.GetComponent<ObjectFlatSpawner>().enabled = false;
            theGenerator.GetComponent<ObjectTallSpawner>().enabled = true;
            musicMedium.Play();
        }
        else
        {
            theGenerator.GetComponent<ObjectSpawner>().enabled = true;
            theGenerator.GetComponent<ObjectFlatSpawner>().enabled = true;
            theGenerator.GetComponent<ObjectTallSpawner>().enabled = true;
            musicHard.Play();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(isPlaying && !isPaused)
        {
            timer += Time.deltaTime;
        }
        if(hitCounter <= 0 && !hit3)
        {
            hit3 = true;
            isPlaying = false;
            musicEasy.Stop();
            musicMedium.Stop();
            musicHard.Stop();
            failSound.Play();
            StartCoroutine(audioHandler());

            DestroyableObject[] objectsToDelete = FindObjectsOfType<DestroyableObject>();
            for (int i = 0; i < objectsToDelete.Length; i++)
            {
                objectsToDelete[i].gameObject.SetActive(false);
            }

            mainMenuCube.SetActive(true);
            mainMenuText.SetActive(true);
            restartCube.SetActive(true);
            restartCube.gameObject.GetComponent<boxSceneChanger>().difficulty = PlayerPrefs.GetString("Level Difficulty");
            restartText.SetActive(true);
            mainMenuTitle.SetActive(true);
            restartTitle.SetActive(true);
            hitsText.SetActive(false);
            timerText.transform.position = new Vector3(0, timerText.transform.position.y, timerText.transform.position.z);

            ScoreManager.TrySetHighScore(Mathf.FloorToInt(timer));
        }
        
	}

    IEnumerator audioHandler()
    {
        while (failSound.isPlaying)
        {
            yield return new WaitForSeconds(.1f);
        }
        
        failMusic.Play();
    }
}
