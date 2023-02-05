using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFile : MonoBehaviour
{

    public GameObject filePrefab;
    public float respawnTime;
    private Vector3 screenBounds;
    public bool isPlaying;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FileWave());
    }

    // Update is called once per frame
    IEnumerator FileWave()
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(respawnTime);
            CreateFile();
        }
    }

    void CreateFile()
    {
        GameObject file = Instantiate(filePrefab) as GameObject;
        file.transform.position = new Vector3(screenBounds.x * 2, Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0,0, Camera.main.transform.position.z)).y, screenBounds.y), filePrefab.transform.position.z);
    }
}
