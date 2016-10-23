using UnityEngine;
using System.Collections;

public class CameraSwtiching : MonoBehaviour {

    public static CameraSwtiching inst;
    
    public Camera TacticalCam;
    public Vector3 locationTogoto;
    public Camera FirstPersonCam;
    private bool CamSwitch = false;

    void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
        TacticalCam.GetComponent<Camera>();
        FirstPersonCam.GetComponent<Camera>();
        TacticalCam.enabled = true;
        FirstPersonCam.enabled = false;
      
    }
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && CamSwitch == false)
        {
            Debug.Log("Switch");
            TacticalCam.enabled = false;
            FirstPersonCam.enabled = true;
            CamSwitch = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && CamSwitch == true)
        {
            TacticalCam.enabled = true;
            FirstPersonCam.enabled = false;
            CamSwitch = false;
        }

    }
}
