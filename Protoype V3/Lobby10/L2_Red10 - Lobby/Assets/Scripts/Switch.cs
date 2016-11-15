using UnityEngine;
//using UnityEngine.Networking;
using System.Collections;

public class Switch : MonoBehaviour
{
    public static Switch inst; //Declare the variable
    [SerializeField]
    private int unitsLeftBeforeSwitch, playerTurn = 1;
    private int defaultUnitAmounts;

    //public GameObject firstPerson;
    public Camera tactCam;

    [SerializeField]
    private GameObject player;


    private void Awake() //Initialise the variable
    {
        inst = this;
    }

    void Start()
    {
        //firstPerson.SetActive(false);
        tactCam.enabled = true;
    }

//    public override void OnStartLocalPlayer()
//    {
//        StartCoroutine(delayedCode());
//        tactCam.enabled = true;
//        firstPerson.enabled = false;
//    }

    IEnumerator delayedCode()
    {
        yield return new WaitForSeconds(0.1f);

        unitsLeftBeforeSwitch = UnitManager.inst.GetNumberOfPlayerUnits(1); //Get the amount of units found in the list
        defaultUnitAmounts = unitsLeftBeforeSwitch;
    }

    private void FixedUpdate()
    {
        if (unitsLeftBeforeSwitch == 0) //If no units are left to control before switch, then switch
        {
            //tactCam.enabled = true;
            //firstPerson.enabled = false;

            //Switch the player turn
//            SetUnitsLeftBeforeSwitchToDefault();
//            UnitManager.inst.SelectUnit(null);
//            ResetEnergyOfAllUnits();
//            if (playerTurn == 1)
//            {
//                playerTurn = 2;
//               
//            }
//            else if (playerTurn == 2)
//            {
//                playerTurn = 1;
//           
//            }
        }
       
    }

    private void ResetEnergyOfAllUnits() //This will loop through the contents of the players in both lists for the players owned by each player and reset the energy values
    {
        foreach (GameObject player1 in UnitManager.inst.GetContentsOfList(1)) //Get contents of the list holding all of player 1s units and reset each energy value
        {
            UnitInfo infoScript = player1.GetComponent<UnitInfo>();
            infoScript.ResetEnergy();
        }
        foreach (GameObject player2 in UnitManager.inst.GetContentsOfList(2)) //Get contents of the list holding all of player 2s units and reset each energy value
        {
            UnitInfo infoScript = player2.GetComponent<UnitInfo>();
            infoScript.ResetEnergy();
        }
    }

    public Camera GetTacticalCamera() //Get the tactical camera without exposing variables
    {
        return tactCam;
    }

    public void MoveCameraToSelectedUnit()
    {
        if (UnitManager.inst.GetContentsOfList(1).Count == 3)
        {
            Camera.main.transform.position = UnitManager.inst.GetSelectedUnit().transform.position; //Transform the fps camera to the selected unit
            //These two lines aren't being ran
            //tactCam.enabled = false; //Disable the tactical camera
            //firstPerson.transform.parent = null; //Unparent the camera from the old object
            Camera.main.transform.parent = UnitManager.inst.GetSelectedUnit().GetComponent<CharacterMovement>().dock.transform;
            Camera.main.transform.rotation = UnitManager.inst.GetSelectedUnit().GetComponent<CharacterMovement>().dock.transform.rotation;
            //firstPerson.transform.parent = UnitManager.inst.GetSelectedUnit().transform; //Parent it with the selected object

            //firstPerson.SetActive(false);
            //firstPerson.SetActive(true); //Enable the tactical camera  
        }
     
    }

    public void DecreaseUnitsLeftBeforeSwitch() //Decrease the amount of units before switch
    {
        unitsLeftBeforeSwitch--;
    }

    public void SetUnitsLeftBeforeSwitchToDefault() //Set units left before the switch back to default for the next player
    {
        unitsLeftBeforeSwitch = defaultUnitAmounts;
    }

    public int GetPlayerTurn() //When called will return the player whos turn it is
    {
        return playerTurn;
    }

}
