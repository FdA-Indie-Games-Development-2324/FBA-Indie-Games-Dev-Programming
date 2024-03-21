using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListExample : MonoBehaviour
{
    GameObject[] spawners;
    public GameObject tree;

    public List<GameObject> SpawnPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("SpawnPoints");

        for(int i = 0; i < spawners.Length; i++)
        {
            SpawnPoints.Add(spawners[i]);
        }

        StartCoroutine(Generate());
    }

    void SpawnTrees()
    {
        for(int i = 0; i < SpawnPoints.Count; i++)
        {
            Instantiate(tree, SpawnPoints[i].transform);
        }
    }

    void RemoveTrees()
    {
        for(int i = SpawnPoints.Count - 1; i >= 0; i--)
        {
            bool coinFlip = (Random.Range(0, 2) == 0);
            if(coinFlip == true){
                SpawnPoints.RemoveAt(i);
            }
        }
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(1);
        RemoveTrees();
        yield return new WaitForSeconds(1);
        SpawnTrees();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
