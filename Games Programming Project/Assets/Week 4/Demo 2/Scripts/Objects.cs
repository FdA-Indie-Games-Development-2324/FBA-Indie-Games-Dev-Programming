using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public float Spawntime;
    public GameObject[] floorObjects;
    

    public List<GameObject> floorSpawnpoints= new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoom());
    }


    IEnumerator SpawnRoom(){
        FindObjectwithTag("SpawnPoints");
        //spawns floor objects
        for(int i = 0; i < floorSpawnpoints.Count; i++){
            GameObject FirstItem = Instantiate(floorObjects[Random.Range(0,floorObjects.Length)], floorSpawnpoints[i].transform);
            yield return new WaitForSeconds(Spawntime);
        } 
    }

    public void FindObjectwithTag(string _tag)
    {
        if (string.Equals(_tag, "SpawnPoints")){
            floorSpawnpoints.Clear();
            Transform parent = transform;
            GetChildObject(parent, _tag);
        }
    }
 
    public void GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {

            if (string.Equals(_tag, "SpawnPoints")){
                Transform child = parent.GetChild(i);
                if (child.tag == _tag)
                {
                    floorSpawnpoints.Add(child.gameObject);
                }
                if (child.childCount > 0)
                {
                    GetChildObject(child, _tag);
                }
            }
        }
    }
}
