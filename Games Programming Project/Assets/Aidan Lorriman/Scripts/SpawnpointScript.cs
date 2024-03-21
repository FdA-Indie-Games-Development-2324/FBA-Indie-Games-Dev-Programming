using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnpointScript : MonoBehaviour
{
    public GameObject LevelPrefab, SpawnPoint;
    public int gridX;
    public int gridY;
    public float generateTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LevelSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name); //When the "l" key on the keyboard is pressed, it reloads the scene.
        }
    } 

    IEnumerator LevelSpawn()
    {
        for(int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridY; j++)
            {
                GameObject room = Instantiate(LevelPrefab, SpawnPoint.transform);
                room.transform.parent = null;
                SpawnPoint.transform.position = new Vector3(transform.position.x, 0, transform.position.z + 10);
                yield return new WaitForSeconds(generateTime);
            }

            SpawnPoint.transform.position = new Vector3(transform.position.x + 10, transform.position.y, 0);
        }
    }
}
