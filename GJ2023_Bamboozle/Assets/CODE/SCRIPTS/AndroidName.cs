using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidName : MonoBehaviour
{
    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string randomCharacters;
    int randomNumbers;
    public string androidName;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<4; i++)
        {
            randomCharacters += characters[Random.Range(0, characters.Length)];
        }
        randomNumbers = Random.Range(0000, 9999);
        androidName = (randomNumbers.ToString("0000") + randomCharacters);
        print(androidName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
