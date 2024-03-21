using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGenerate : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject SpawnPoint;
    public int gridX;
    public int gridY;
    public float generateTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WorldSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

    IEnumerator WorldSpawn()
    {
        for(int i = 0; i < gridX; i++)
        {
            for(int j = 0; j < gridY; j++)
            {
                GameObject room = Instantiate(roomPrefab, SpawnPoint.transform);
                room.transform.parent = null;
                SpawnPoint.transform.position = new Vector3(transform.position.x, 0, transform.position.z + 10);
                yield return new WaitForSeconds(generateTime);
            }

            SpawnPoint.transform.position = new Vector3(transform.position.x + 10, transform.position.y, 0);
        }
    }
}
