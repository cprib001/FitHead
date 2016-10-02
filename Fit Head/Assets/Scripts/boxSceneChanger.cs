using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class boxSceneChanger : MonoBehaviour {

    public int sceneInt;
    public string difficulty;
    public AudioSource effect;
    public AudioSource music;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnTriggerEnter(Collider col){
        music.Stop();
        effect.Play();
        PlayerPrefs.SetString("Level Difficulty", difficulty);
        StartCoroutine(startScene());
    }

    IEnumerator startScene()
    {
        while (effect.isPlaying)
        {
            yield return new WaitForSeconds(.1f);
        }
        SceneManager.LoadScene(sceneInt);
    }
}
