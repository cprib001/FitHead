using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {

    public GameObject ObjectDestructionPoint;

	// Use this for initialization
	void Start () {
        ObjectDestructionPoint = GameObject.Find("Object Destroyer Point");
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.z > ObjectDestructionPoint.transform.position.z)
        {
            gameObject.SetActive(false);
        }
	}
}
