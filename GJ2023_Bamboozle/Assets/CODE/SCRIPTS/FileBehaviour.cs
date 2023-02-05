using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileBehaviour : MonoBehaviour
{
    
    public bool isUseful;
    public bool isGrabbingFile;
    public int fileCategory;
    public bool insideFolder;
    [SerializeField]
    float timeFluctuation;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        fileCategory = Random.Range(1, 6);
        isUseful= (Random.value > 0.5f);
        if (gameManager == null)
        gameManager = GameObject.FindWithTag("GameManager");
        isGrabbingFile = false;

        switch(fileCategory)
        {
            case 1:
            if(isUseful)
                {

                }
            else
                {

                }
            break;

            case 2:
                if (isUseful)
                {

                }
                else
                {

                }
                break;

            case 3:
                if (isUseful)
                {

                }
                else
                {

                }
                break;

            case 4:
                if (isUseful)
                {

                }
                else
                {

                }
                break;

            case 5:
                if (isUseful)
                {

                }
                else
                {

                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            gameManager.GetComponent<ShowCursor>().CursorUpdate(false);
            if(!insideFolder)
            isGrabbingFile = false;
        }

        FilePosition();
    }

    void FilePosition()
    {
        if (isGrabbingFile)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, gameObject.transform.position.z);
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            gameManager.GetComponent<ShowCursor>().CursorUpdate(true);
            isGrabbingFile=true;
        }
    }

    private void OnMouseDown()
    {
        FileDelete();
    }

    void FileDelete()
    {
        if (isUseful)
        {
            gameManager.GetComponent<CountdownTimer>().timeRemaining += timeFluctuation;
            Destroy(gameObject);
        }
        else if (!isUseful)
        {
            gameManager.GetComponent<CountdownTimer>().timeRemaining -= timeFluctuation;
            Destroy(gameObject);
        }
    }

    
}
