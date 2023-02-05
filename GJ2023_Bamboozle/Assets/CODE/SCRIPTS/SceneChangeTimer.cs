using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTimer : MonoBehaviour
{
    public string sceneName;
    public float timeToChangeScene = 160.0f;

    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeToChangeScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
