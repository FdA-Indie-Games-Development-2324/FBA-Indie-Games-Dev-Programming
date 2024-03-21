using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    public GameObject[] spawnPoints; //An array of SpawnPoints
    public GameObject[] objectPrefabs;//An arry of the object prefabs
    

    public List<GameObject> SpawnPoints = new List<GameObject>();// Sorts the spawnpoints into a list

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints"); //Looks for the GameObject that is label "Spawnpoints"

        for(int i = 0; i < spawnPoints.Length; i++){
			SpawnPoints.Add (spawnPoints[i]);
		}
        for (int i = 0; i < SpawnPoints.Count; i++){
            SpawnPoints.RemoveAt(Random.Range(0, SpawnPoints.Count - 1));
        }
        StartCoroutine (GenerateAllFancy());
    }

    IEnumerator GenerateAllFancy() {
        for(int i = 0; i < SpawnPoints.Count; i++){
            if (i == 0){
                GameObject FirstItem = Instantiate(objectPrefabs[Random.Range(0,objectPrefabs.Length)], SpawnPoints[i].transform); // Picks the first item, chooses the coliour for it and randomly places it in the level
                FirstItem.GetComponent<Renderer>().material.color = new Color (1f, 0.5f, 0f);
                yield return new WaitForSeconds(0.5f);
            } 
            
            else if ( i == SpawnPoints.Count-1) {
                GameObject LastItem = Instantiate(objectPrefabs[Random.Range(0,objectPrefabs.Length)], SpawnPoints[i].transform);// Picks the last item, chooses the colour and places it randoly in the scene
                LastItem.GetComponent<Renderer>().material.color = new Color (1f, 0.5f, 0f);
                yield return new WaitForSeconds(0.5f);
            } 
            else {
                Instantiate(objectPrefabs[Random.Range(0,objectPrefabs.Length)], SpawnPoints[i].transform);
                yield return new WaitForSeconds(0.5f);
                
            }
		}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){ //Pressing the "F" key to reload the scene
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
