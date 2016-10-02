using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public GameManagerScript theGameManager;

    public Text hitCounterText;
    public Text timerText;
    public AudioSource hitEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hitCounterText.text = "Hits:\n" + theGameManager.hitCounter;
        timerText.text = "Score:\n" + Mathf.FloorToInt(theGameManager.timer);
    }

    void OnTriggerEnter(Collider other)
    {
        if(theGameManager.hitCounter > 0)
        {
            theGameManager.hitCounter--;
            hitEffect.Play();
            StartCoroutine(audioHandler());
        }
    }

    IEnumerator audioHandler()
    {
        while (hitEffect.isPlaying)
        {
            yield return new WaitForSeconds(.1f);
        }
    }
}
