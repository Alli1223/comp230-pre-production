using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
	//Declare the signleton
	public static TimeController instance;
	
	//References for all the things that need to be paused or unpaused
	[SerializeField]
	private GameObject tacticalCamera, FPScamera, ai, energyController;
    public GameObject player1, player2;
    [SerializeField]
    private float defaultTacticalCameraSpeed, defaultFPScameraSpeedX, defaultFPScameraSpeedY, defaultAISpeed;
    public float  defaultEnergyDrain, defaultPlayerSpeed;

	public bool isPaused = false;

	
	void Awake()
	{
		instance = this;  //Initialise the singleton
	}
	
	void Start()
	{
        
        //Get all the default speeds
        defaultTacticalCameraSpeed = tacticalCamera.GetComponent<CameraRotate>().speed;
		defaultFPScameraSpeedX = FPScamera.GetComponent<CameraMovement>().sensX;
        defaultFPScameraSpeedY = FPScamera.GetComponent<CameraMovement>().sensY;

        defaultPlayerSpeed = player1.GetComponent<BasicMovement>().speed;
		//defaultAISpeed = ai.GetComponent<aiMovement>().movementSpeed;
		defaultEnergyDrain = energyController.GetComponent<EnergyScript>().energyDrain;

        //Pause the game because kate wants this
        Pause();
	}
	
	void Update()
	{
		//If the game is paused
		if (Input.GetKeyUp(KeyCode.Escape) && isPaused == false)
		{
			Pause();
		}
		else if (Input.GetKeyUp(KeyCode.Escape) && isPaused == true)
		{
			UnPause();
		}
	}
	
	public void Pause()
	{
		//Tell the controller its paused
		isPaused = true;
		
		
		//tacticalCamera.GetComponent<CameraRotate>().speed = 0;
		FPScamera.GetComponent<CameraMovement>().sensX = 0;
        FPScamera.GetComponent<CameraMovement>().sensY = 0;
        player1.GetComponent<BasicMovement>().speed = 0;
        player2.GetComponent<BasicMovement>().speed = 0;
		//ai.GetComponent<aiMovement>().movementSpeed = 0;
		energyController.GetComponent<EnergyScript>().energyDrain = 0;
		
	}
	
	public void UnPause()
	{
		//Tell the controller its no longer paused
		isPaused = false;

        tacticalCamera.GetComponent<CameraRotate>().speed = defaultTacticalCameraSpeed;
        FPScamera.GetComponent<CameraMovement>().sensX = defaultFPScameraSpeedX;
        FPScamera.GetComponent<CameraMovement>().sensY = defaultFPScameraSpeedY;
        //ai.GetComponent<aiMovement>().movementSpeed = 0;
        energyController.GetComponent<EnergyScript>().energyDrain = defaultEnergyDrain;
        if (EnergyScript.inst.p1 == true)
        {
            player1.GetComponent<BasicMovement>().speed = defaultPlayerSpeed;
        }
        else if (EnergyScript.inst.p2 == true)
        {
            player2.GetComponent<BasicMovement>().speed = defaultPlayerSpeed;
        }
    }
}