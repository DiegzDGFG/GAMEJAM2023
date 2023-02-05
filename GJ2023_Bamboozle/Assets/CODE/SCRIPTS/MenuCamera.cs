using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCamera : MonoBehaviour
{
   

    public void LoadScene()
    {
        SceneManager.LoadScene("LoreScene");
    }
}
