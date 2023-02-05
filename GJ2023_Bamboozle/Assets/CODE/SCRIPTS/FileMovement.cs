using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FileMovement : MonoBehaviour
{
    private float cycle;
    private Vector3 basePosition;

    public float waveSpeed = 2f;
    public float bonusHeight = 0.5f;
    

    public float timeFluctuation;
    public GameObject gameManager;

   public AudioSource audioSource;

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    float countdownForPos;
    public float countdownForLeaving;
    float moveSpeed;
    public float maxMoveSpeed;
    public float minMoveSpeed;
    float minFlightX, maxFlightX, minFlightY, maxFlightY;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        

        gameManager = GameObject.FindWithTag("GameManager");
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        countdownForPos = 0;
        minFlightX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        maxFlightX = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z)).x;
        minFlightY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.transform.position.z)).y;
        maxFlightY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y;
       
    }

    // Update is called once per frame
     void Update()
     {
        cycle += Time.deltaTime * waveSpeed;

         countdownForLeaving -= Time.deltaTime;
         if(countdownForLeaving < 0)
         {
            basePosition = transform.position;
            transform.position = basePosition + (Vector3.up * bonusHeight) * Mathf.Sin(cycle);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x+10000, transform.position.y, transform.position.z) , moveSpeed);
             if(transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, 0,0)).x)
             {

                 gameManager.GetComponent<CountdownTimer>().timeRemaining -= timeFluctuation;
                //Audio de Se Escapa File
            
                 Destroy(gameObject);
                 

             }
         }

        if (countdownForPos > 0 && countdownForLeaving > 0)
        {
            basePosition = transform.position;
            transform.position = basePosition + (Vector3.up * bonusHeight) * Mathf.Sin(cycle);
            transform.position = Vector3.MoveTowards(transform.position , targetPosition, moveSpeed);
             countdownForPos -= Time.deltaTime;
         }
         else if (countdownForPos<=0)
         {
             targetPosition = new Vector3(Random.Range(minFlightX, maxFlightX), Random.Range(minFlightY, maxFlightY), transform.position.z);
           
            
             countdownForPos = Random.Range(0.3f, 1f);
         }

     } 

   /* private void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter);
        float y = Mathf.Sin(timeCounter);
        float z = 0;
        transform.position = new Vector3(x, y, z);
    } */
}
