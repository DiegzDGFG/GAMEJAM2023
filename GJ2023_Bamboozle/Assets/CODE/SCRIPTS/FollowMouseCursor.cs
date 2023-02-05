using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    Vector3 pos;

    public float offset = 5f;

    void Update()

    {

        pos = Input.mousePosition;

        pos.z = offset;

        transform.position = Camera.main.ScreenToWorldPoint(pos);

    }


}
