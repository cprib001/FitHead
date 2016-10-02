using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{

    public float moveSpeed;

    public float t = 0;

    // Use this for initialization
    void Start()
    {
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.SetColor("_Color", Color.green);
        GetComponent<MeshRenderer>().material = newMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);

        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.green, Color.red, t);
        if (t < 1)
        { // while t below the end limit...
          // increment it at the desired rate every update:
            t += 0.005f;
        }
    }

    void OnEnable()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
        t = 0;
    }

}
