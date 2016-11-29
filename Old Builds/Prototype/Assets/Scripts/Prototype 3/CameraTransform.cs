using UnityEngine;
using System.Collections;

public class CameraTransform : MonoBehaviour
{
    //Decalre the singleton
    public static CameraTransform instance;

    public Transform p1CameraPosition, p2CameraPosition;
    public Camera thisCamera;
    
    void Awake() //Initialise the singleton
    {
        instance = this;
    }

    void Start()
    {
        thisCamera = this.gameObject.GetComponent<Camera>();
    }


}
