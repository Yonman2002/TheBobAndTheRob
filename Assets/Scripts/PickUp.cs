using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Vector3 objectPos;
    public float distance;
    public Rigidbody rigidbody;
    public float maxDistance;
    public AudioClip Clip;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        distance = Vector3.Distance(transform.position, PlayerController.player.transform.position);
        if (Input.GetButtonDown("PickUp"))
        {
            //Debug.Log("hi from input 'e'");            
            if (distance <= maxDistance)
            {
                Debug.Log("Yay");
                PlayerController.player.Grab(this);
            }
        }
    }
}
