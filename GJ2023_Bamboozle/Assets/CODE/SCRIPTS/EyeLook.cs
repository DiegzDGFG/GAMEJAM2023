using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
    public Transform eyeDestination;
    

    void Update()
    {
        transform.LookAt(eyeDestination);
    }
}
