using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float SpawnObj;
    public GameObject[] Obsticles;

    public List<GameObject> ObstSpawnpoints= new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoom());
    }

    IEnumerator SpawnRoom(){
        FindObjectwithTag("SpawnPoint");

        for(int i = 0; i < ObstSpawnpoints.Count; i++){
            GameObject FirstItem = Instantiate(Obsticles[Random.Range(0,Obsticles.Length)], ObstSpawnpoints[i].transform);
            yield return new WaitForSeconds(Spawntime);
        }

    public void FindObjectWithTag(string PLBL)
    {
        if (string.Equals(PLBL, "SpawnPoint")){
            ObstSpawnpoints.Clear();
            Transform parent = transform;
            GetChildObject(parent, PLBL);
        }
    }
    }


}
