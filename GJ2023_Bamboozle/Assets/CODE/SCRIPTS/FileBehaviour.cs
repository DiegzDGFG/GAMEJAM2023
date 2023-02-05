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

    [SerializeField]
    Texture[] textures;

    [SerializeField]
    AudioClip[] audios;

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
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, 2)];
                }
            else
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(2, 4)];
                }
            break;

            case 2:
                if (isUseful)
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(4, 6)];
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(6, 8)];
                }
                break;

            case 3:
                if (isUseful)
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(8, 10)];
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(10, 12)];
                }
                break;

            case 4:
                if (isUseful)
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(12, 14)];
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(14, 16)];
                }
                break;

            case 5:
                if (isUseful)
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(16, 18)];
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(18, 20)];
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            //Audio de soltar File (no en folder)
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
            //Audio de Agarrar File
            gameManager.GetComponent<ShowCursor>().CursorUpdate(true);
            isGrabbingFile=true;
        }
    }

    private void OnMouseDown()
    {
        //Audio de Disparar
        FileDelete();
    }

    void FileDelete()
    {
        if (isUseful)
        {
            gameManager.GetComponent<AudioSource>().clip = audios[Random.Range(2, 5)];
            gameManager.GetComponent<AudioSource>().Play();
            gameManager.GetComponent<AudioSource>().Play();
            gameManager.GetComponent<CountdownTimer>().timeRemaining -= timeFluctuation;
            Destroy(gameObject);
        }
        else if (!isUseful)
        {
            gameManager.GetComponent<AudioSource>().clip = audios[Random.Range(0, 2)];
            
            gameManager.GetComponent<AudioSource>().Play();
            gameManager.GetComponent<CountdownTimer>().timeRemaining += timeFluctuation;
            Destroy(gameObject);
        }
    }

    
}
