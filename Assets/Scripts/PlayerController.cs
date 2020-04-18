using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float horizontal;
    private float vertical;

    public static PlayerController player;
    public GameObject PauseScreen;
    //public AdvancedAnimation idle;
    //public AdvancedAnimation walk;
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
                Time.timeScale = 0;
                PauseScreen.SetActive(true);
            }
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //Vector3 trueSpeed = new Vector3(horizontal * speed, rigidBody.velocity.y, vertical * speed);
        Vector3 trueSpeed = (vertical * transform.forward + horizontal * transform.right) * speed;
        trueSpeed.y = rigidBody.velocity.y;
        /*if (horizontal != 0 || vertical != 0)
        {
            idle.Active = false;
            walk.Activate(true);
        }
        else
        {
            idle.Activate(true);
            walk.Active = false;
        }*/
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
        rigidBody.velocity = trueSpeed;        
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }
}
