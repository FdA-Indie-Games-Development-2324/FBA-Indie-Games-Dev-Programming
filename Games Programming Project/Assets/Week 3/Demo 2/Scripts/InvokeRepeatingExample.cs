using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepeatingExample : MonoBehaviour
{
    public GameObject spawningObject;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //What happens if you change these values?
        InvokeRepeating("Spawn", 3f, 0.5f);
    }

    void Spawn()
    {
        GameObject clone = Instantiate(spawningObject, spawnPoint);
        clone.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
