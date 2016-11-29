using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour
{
    //Author:Kate Georgiou 23/9/16 Desc: attach to the camera to allow the camera to focus on the player when zooming.
    [SerializeField]
    private Transform target;
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);
	}
}
