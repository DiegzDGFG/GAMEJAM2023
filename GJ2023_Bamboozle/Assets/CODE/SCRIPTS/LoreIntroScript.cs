using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreIntroScript : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("EMIL SCENE HERE", LoadSceneMode.Single);
    }
}
