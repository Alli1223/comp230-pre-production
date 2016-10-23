using UnityEngine;
using System.Collections;
//Author: KATE GEORGIOU 21/9/16 Desc: pauses the game when escape is paused so that the game can be exited without the camera going crazy due to not being clamped.

public class Pause : MonoBehaviour {
  //  private int speed = 50;
    
    //TO USE: attach to a random empty game object and then drag the camera on in the editor :)
    void Start()
    {
       
    }
	
	// Update is called once per frame
	void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape)) //when escape is pressed...
        {
            if (Time.timeScale == 1f) //and time is moving...
            {
                //CameraRotate.inst.movementAllowed = true;
                Time.timeScale = 0f; //pause the game...
                CameraMovement.instance.allowedToMove = false; //and make sure the camera can't move.
                Debug.Log("time paused");
            }
            else //otherwise....
            {
                Time.timeScale = 1f; //when esc. is pressed resume time moving...
                CameraMovement.instance.allowedToMove = true; //..and resume camera movement.
            }
        }
       
        


	}
}
