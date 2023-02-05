using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D normalCursor;

    [SerializeField]
    private Texture2D grabbingCursor;

    private Vector2 hotSpot = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(normalCursor, hotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    
    public void CursorUpdate(bool mouseIsGrabbing)
    {
        if(!mouseIsGrabbing)
        Cursor.SetCursor(normalCursor, hotSpot, CursorMode.Auto);
        else if (mouseIsGrabbing)
        Cursor.SetCursor(grabbingCursor, hotSpot, CursorMode.Auto);
    }

}
