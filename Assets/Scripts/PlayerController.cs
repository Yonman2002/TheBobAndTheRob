using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float horizontal;
    private float vertical;

    public PickUp pickUp;
    public static PlayerController player;
    public GameObject PauseScreen;
    public AdvancedAnimation idle;
    public AdvancedAnimation walk;
    public Transform CollisionPos;
    public float JumpForce;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                PauseScreen.SetActive(true);
            }
        }
        if (Time.timeScale == 0)
        {
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //Vector3 trueSpeed = new Vector3(horizontal * speed, rigidBody.velocity.y, vertical * speed);
        Vector3 trueSpeed = (vertical * transform.forward + horizontal * transform.right) * speed;
        trueSpeed.y = rigidBody.velocity.y;
        if (horizontal != 0 || vertical != 0)
        {
            idle.Active = false;
            walk.Activate(true);
        }
        else
        {
            idle.Activate(true);
            walk.Active = false;
        }
        if (Input.GetButton("Jump"))
        {
            if (Physics.CheckBox(CollisionPos.position, CollisionPos.localScale, Quaternion.identity, ~(1 << 8)))
            {
                trueSpeed.y = JumpForce;
                /*if (!JumpingAnimation.Active)
                {
                    ActivateAnimation(JumpingAnimation);
                    source.PlayOneShot(JumpSounds[Random.Range(0, JumpSounds.Length)]);
                }*/
            }
        }

        if (Input.GetButtonDown("PickUp"))
        {
            if (pickUp != null)
            {
                Release();
            }
        }
        rigidBody.velocity = trueSpeed;        
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }

    public void Grab(PickUp pick)
    {
        if (pickUp != null)
        {
            Release();
        }
        pickUp = pick;
        Destroy(pickUp.rigidbody);
        pickUp.isHolding = true;
        pickUp.gameObject.transform.SetParent(pickUp.tempParent.transform);
    }

    public void Release()
    {
        //Debug.Log("hi from release");
        if (pickUp != null)
        {
            if (pickUp.rigidbody == null)
            {
                pickUp.rigidbody = pickUp.gameObject.AddComponent<Rigidbody>();
            }
            else
            {
                pickUp.rigidbody =pickUp.GetComponent<Rigidbody>();
            }
            pickUp.isHolding = false;
            pickUp.objectPos = pickUp.gameObject.transform.position;
            pickUp.gameObject.transform.SetParent(null);            
            pickUp.rigidbody.useGravity = true;
            pickUp.gameObject.transform.position = pickUp.objectPos;
            pickUp = null;
        }        
    }
}
