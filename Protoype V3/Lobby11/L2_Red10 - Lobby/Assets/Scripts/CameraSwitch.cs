//------------------------------------------------------------------------------------------------------
// Author : Ross Perry 
// Date : 14 / 11 / 2016  
// Description : Manager to handle all functionality relating to camera switching
// Features a singleton so that the camera location is always the same and functions to manage switching
//-------------------------------------------------------------------------------------------------------


using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CameraSwitch : NetworkBehaviour
{
    //Defines the script as a singleton
    public static CameraSwitch instance;

    private bool allUnitsPlaced = false;

    //Prevents problems if more than one instance of this singleton is used
    void Awake ()
    {
        if (instance != null) 
        {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }

    }

    //Makes sure the camera is in the correct state when network clients are started
    void OnStartClient() 
    {
        Camera.main.enabled = true; 
    }

    public void MoveCameraToSelectedUnit()
    {
        if (UnitManager.inst.GetContentsOfList(1).Count == 3 && UnitManager.inst.GetContentsOfList(2).Count == 3)  //Checks if all units have been placed
        {
            allUnitsPlaced = true;

            if (allUnitsPlaced == true)
            {
                Camera.main.transform.position = UnitManager.inst.GetSelectedUnit().transform.position; //Transform the fps camera to the selected unit

                Camera.main.transform.parent = UnitManager.inst.GetSelectedUnit().GetComponent<CharacterMovement>().dock.transform; //Parent to camera dock

                Camera.main.transform.rotation = UnitManager.inst.GetSelectedUnit().GetComponent<CharacterMovement>().dock.transform.rotation; //Set new rotation

                //firstPerson.transform.parent = null; //Unparent the camera from the old object
                //To be added: disable and enable the setup script to coincide with the switch (enable movement etc)
            } 
            else
            {
                return;
                //Send message to players "Not all units are placed"
            }

        }
            
    }

    //W.I.P
    void AssignNetworkHost()
    {
        //run NetworkManager.StartHost();  
    }

    void AssignNetworkClient()
    {
        //run NetworkManager.StartClient();
    }
}
