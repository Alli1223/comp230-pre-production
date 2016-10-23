using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
    //23/9/16 Desc: this script is attached to the camera and also attach a rigidbody to the camera. Dont forget to add the CameraLookAt script too.
{
    [SerializeField]
    private int minimumZoom = -20, maximumZoom = 20, Speed = 100;
    private Rigidbody rb;
    private Transform defaultMove;
	[SerializeField]
	private float initialZ;
    // Use this for initialization
    void Start()
    {
        //default position of the camera
        defaultMove = this.gameObject.transform;
		initialZ = defaultMove.position.z;
        //Rigidbody that will be moved
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		float currentZaxis = transform.position.z;
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0) 
		{ 
			if (initialZ - maximumZoom < currentZaxis) //Clamp
			{
				rb.velocity = rb.transform.forward * -Speed;
			} 
		}
        //Zoom out
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) 
		{ 
			if (initialZ + maximumZoom > currentZaxis) //Clamp
			{
				rb.velocity = rb.transform.forward * Speed; 
			}
		}
		//Stop 
        else { rb.velocity = rb.transform.forward * 0; }
    }
}
