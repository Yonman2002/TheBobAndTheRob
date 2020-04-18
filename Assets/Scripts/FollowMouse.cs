using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    /*private Vector3 mousePosition;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = -6;
        transform.position = Vector2.Lerp(transform.position + new Vector3(0, 0, -6), mousePosition, moveSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -6);
    }*/


    private float rotationX;
    private float rotationY;

    public bool showCursor;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        rotationX = rotationX - Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = rotationY + Input.GetAxis("Mouse X") * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
