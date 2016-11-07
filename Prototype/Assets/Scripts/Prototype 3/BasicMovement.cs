using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

//Author: Kate Georgiou 20/9/16 Desc: Basic character movement for prototypes.
//This script will obviously need to be attached to the player game object. However it does need to be better optimised so that the player follows the camera direction they are facing.
//Make sure to tag any floors or surfaces that the player will be walking on as 'Floor' so the script can find them.

public class BasicMovement : NetworkBehaviour
{

    public float speed = 5; //can be editied in the editor without being able to be acssessed by other scripts.
    private Rigidbody rb;
    private bool Grounded = true; //detects if the player is colliding with the 'floor' game object and if not then they can't jump.
    [SerializeField]
    private bool abilityToJump = true; //turn off in the editor if you don't want jumping in the game.
    [SerializeField]
    private int ForceInJump = 150; //change this in the editor if the jump needs more force behind it.
    [SerializeField]
    private Camera cam;

    // Use this for initialization
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            if (UniSelect.inst.selectedObject == this.gameObject)
            {

                if (Input.GetKey(KeyCode.W))
                {
                    rb.velocity = cam.gameObject.transform.forward * speed;
                    Jump();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.velocity = cam.gameObject.transform.forward * -speed;
                    Jump();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = cam.gameObject.transform.right * -speed;
                    Jump();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = cam.gameObject.transform.right * speed;
                    Jump();
                }
                Jump();
            }
        }

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true && abilityToJump == true)
        {
            rb.AddForce(0, ForceInJump, 0);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Grounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Grounded = false;
        }
    }
    
}
