using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecallInventory : MonoBehaviour {
    //AUTHOR: KATE GEORGIOU 21/9/16 desc: Brings up and closes the inventory canvas when the player presses I.
    //TO USE: attach to the canvas that will contain the buttons for the inventory slots.

    private Canvas inventoryscreen;

	// Use this for initialization
	void Start ()
    {
        inventoryscreen = this.gameObject.GetComponent<Canvas>(); //will automatically retrive the camera that this script is attached to.
        inventoryscreen.enabled = false; //On start up the inventory canvas is disabled.
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I)) //when I is pressed then it will bring the inventory up and if it is already open then it will close it.
        {
            if (inventoryscreen.enabled == true)
            {
                inventoryscreen.enabled = false;
                CameraMovement.instance.allowedToMove = true;
            }
            else
            {
                inventoryscreen.enabled = true;
                CameraMovement.instance.allowedToMove = false;
            }
            

        }
        

    }
}
