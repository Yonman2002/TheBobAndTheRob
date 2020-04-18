using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Vector3 objectPos;
    private float distance;
    private Rigidbody rigidbody;

    public bool isHolding = false;
    public float maxDistance;
    public GameObject item;
    public GameObject tempParent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = item.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance > maxDistance)
        {
            isHolding = false;
        }
        if (Input.GetButtonDown("PickUp"))
        {
            Debug.Log("hi from input 'e'");
            if (isHolding)
            {
                Debug.Log("hi from release");
                rigidbody.isKinematic = false;
                isHolding = false;
                objectPos = item.transform.position;
                item.transform.SetParent(null);
                rigidbody.useGravity = true;
                item.transform.position = objectPos;
            }
            else if (distance <= maxDistance)
            {
                Debug.Log("hi from hold");
                rigidbody.isKinematic = true;
                isHolding = true;
                rigidbody.useGravity = false;
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                item.transform.SetParent(tempParent.transform);
                //rigidbody.detectCollisions = true;
            }
        }
    }
}
