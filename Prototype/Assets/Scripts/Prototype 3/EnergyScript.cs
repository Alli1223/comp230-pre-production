using UnityEngine;
using System.Collections;

public class EnergyScript : MonoBehaviour {


    public static EnergyScript inst;
   // [SerializeField]
    public bool p1 = true, p2 = false;
    [SerializeField]
    public float energy = 0f, timer;
    public float energyDrain = 2;


    void Awake()
    {
        inst = this;
    }
	// Use this for initialization
	void Start ()
    {
        //start off paused which wont allow the timer to count and therefore won't = decrease in energy.

        timer = 50;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if timer is running...
        //count down.
        //  energy -= energyDrain * Time.deltaTime;
        //if energy = 0 then run switch funtion
        if (energy > 0) //Only drain energy when you have some
        {
            energy -= energyDrain * Time.deltaTime;
        }
        Debug.Log(energy);
        // }
        if (energy <= 0)
        {
          
            Switch();
           // energy = TimeController.instance.defaultEnergyDrain;

        }
    }
    public void Switch()
    {
		energy = 30; //need to find way of retrieving the default so it changes for both players when its changed in editor
        UniSelect.inst.selectedObject = null;
        if (p1 == true)
        {
         
            //switch to p2
            //make p1 false and p2 true
            p1 = false;
            p2 = true;
            //TimeController.instance.player1.GetComponent<BasicMovement>().speed = 0;
          //  TimeController.instance.player2.GetComponent<BasicMovement>().speed = TimeController.instance.defaultPlayerSpeed;
            //parent with player 2

            CameraTransform.instance.thisCamera.transform.parent = null;
           CameraTransform.instance.thisCamera.transform.parent = CameraTransform.instance.p2CameraPosition;

            //Move the camera to player 2
            CameraTransform.instance.thisCamera.transform.position = CameraTransform.instance.p2CameraPosition.parent.position;
            Debug.Log("SwitchingtoP2");

            

        }
        else if (p2 == true)
        {
            //switch to p2
            //make p1 false and p2 true
            p1 = true;
            p2 = false;
            //TimeController.instance.player2.GetComponent<BasicMovement>().speed = 0;
           // TimeController.instance.player1.GetComponent<BasicMovement>().speed = TimeController.instance.defaultPlayerSpeed;
            //parent with player 2

            CameraTransform.instance.thisCamera.transform.parent = null;
           CameraTransform.instance.thisCamera.transform.parent = CameraTransform.instance.p1CameraPosition;
            CameraTransform.instance.thisCamera.transform.position = CameraTransform.instance.p1CameraPosition.parent.position;

            //Move the camera to player 2

            Debug.Log("SwitchingtoP1");

        }
        TimeController.instance.Pause();
        CameraSwtiching.inst.TacticalCam.enabled = true;
        CameraSwtiching.inst.FirstPersonCam.enabled = false;

    }
}
