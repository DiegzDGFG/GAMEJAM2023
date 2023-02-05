using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBehaviour : MonoBehaviour
{
    public GameObject gameManager;
    public int folderCategory;
    public float timeFluctuation;
    public GameObject fileOnTop;
    public Vector3 scaleChange;
    public float maxGrowSize;
    public float minGrowSize;
    bool isGrowing;
    // Start is called before the first frame update
    void Start()
    {
        fileOnTop = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (fileOnTop != null)
        {
            if (Input.GetMouseButtonUp(1) && fileOnTop.GetComponent<FileBehaviour>().fileCategory == folderCategory && fileOnTop.GetComponent<FileBehaviour>().isUseful && fileOnTop.GetComponent<FileBehaviour>().insideFolder)
            {
                gameManager.GetComponent<CountdownTimer>().timeRemaining += timeFluctuation;
                fileOnTop.GetComponent<FileBehaviour>().isGrabbingFile = false;
                fileOnTop.GetComponent<FileBehaviour>().insideFolder = false;
                isGrowing = false;
                Destroy(fileOnTop);
            }
            else if (Input.GetMouseButtonUp(1) && fileOnTop.GetComponent<FileBehaviour>().isUseful == false && fileOnTop.GetComponent<FileBehaviour>().insideFolder)
            {
                gameManager.GetComponent<CountdownTimer>().timeRemaining -= timeFluctuation;
                fileOnTop.GetComponent<FileBehaviour>().isGrabbingFile = false;
                fileOnTop.GetComponent<FileBehaviour>().insideFolder = false;
                isGrowing = false;
                Destroy(fileOnTop);
            }
        }

        GrowFolder();
    }

 
    private void OnTriggerEnter(Collider other)
    {
        fileOnTop = other.gameObject;
        fileOnTop.GetComponent<FileBehaviour>().insideFolder = true;
        if(fileOnTop.GetComponent<FileBehaviour>().isGrabbingFile==true)
        isGrowing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        fileOnTop = other.gameObject;
        fileOnTop.GetComponent<FileBehaviour>().insideFolder = false;
        if (fileOnTop.GetComponent<FileBehaviour>().isGrabbingFile == true)
            isGrowing = false;
    }

    void GrowFolder()
    {
        if (isGrowing)
        {
            if (transform.localScale.x < maxGrowSize)
                transform.localScale += scaleChange;
        }
        else if (!isGrowing)
        {
            if (transform.localScale.x > minGrowSize)
                transform.localScale -= scaleChange;
        }
    }
}
