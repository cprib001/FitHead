using UnityEngine;
using System.Collections;

public class ObjectTallSpawner : MonoBehaviour {

    public GameManagerScript theGameManager;
    public ObjectPooler TheObstaclePool;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public bool isSpawning = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (theGameManager.isPlaying && !isSpawning)
        {
            StartCoroutine(SpawnObstacle());
        }
        isSpawning = theGameManager.isPlaying;
    }

    IEnumerator SpawnObstacle()
    {
        while (theGameManager.isPlaying)
        {

            Vector3 ObstacleVector = new Vector3(transform.position.x + Random.Range(xMin, xMax), transform.position.y + Random.Range(yMin, yMax), transform.position.z);
            GameObject NewObstacle = TheObstaclePool.GetPooledObject();
            NewObstacle.transform.position = ObstacleVector;
            NewObstacle.SetActive(true);
            isSpawning = true;
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
            //yield return new WaitForSeconds(1.0f);
        }

    }
}
