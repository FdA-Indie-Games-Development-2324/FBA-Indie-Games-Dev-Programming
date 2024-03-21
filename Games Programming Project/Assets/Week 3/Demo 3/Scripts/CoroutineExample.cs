using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    public GameObject tree;
    public GameObject[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");

        //Invoke Method
        
        Invoke("SpawnTree", 5);
        Invoke("ColorTree", 6);
        Invoke("RemoveTree", 7);
        
        //StartCoroutine(GenerateAll());
        //StartCoroutine(GenerateAllAgain());
    }

    void SpawnTree()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(tree, spawnPoints[i].transform);
        }
    }
    void ColorTree()
    {
        GameObject[] treeTops;
        treeTops = GameObject.FindGameObjectsWithTag("TreeTop");

        for(int i = 0; i < treeTops.Length; i++)
        {
            treeTops[i].GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
    void RemoveTree()
    {
        GameObject[] treeTrunks;
        treeTrunks = GameObject.FindGameObjectsWithTag("Tree");
        for(int i = 0; i < treeTrunks.Length; i++)
        {
            bool coinFlip = (Random.Range(0, 2) == 0);
            if(coinFlip == true)
            {
                Destroy(treeTrunks[i]);
            }
        }
    }

    /*
    IEnumerator GenerateAll()
    {
        yield return new WaitForSeconds(3);
        SpawnTree();
        yield return new WaitForSeconds(3);
        ColorTree();
        yield return new WaitForSeconds(3);
        RemoveTree();
    }
    */
    /*
    IEnumerator GenerateAllAgain()
    {
        //Spawn Trees
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(tree, spawnPoints[i].transform);
        }
        yield return new WaitForSeconds(3);

        //Colour Trees
        GameObject[] treeTops;
        treeTops = GameObject.FindGameObjectsWithTag("TreeTop");

        for(int i = 0; i < treeTops.Length; i++)
        {
            treeTops[i].GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        yield return new WaitForSeconds(3);

        //Remove Trees
        GameObject[] treeTrunks;
        treeTrunks = GameObject.FindGameObjectsWithTag("Tree");
        for(int i = 0; i < treeTrunks.Length; i++)
        {
            bool coinFlip = (Random.Range(0, 2) == 0);
            if(coinFlip == true)
            {
                Destroy(treeTrunks[i]);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    */
}
