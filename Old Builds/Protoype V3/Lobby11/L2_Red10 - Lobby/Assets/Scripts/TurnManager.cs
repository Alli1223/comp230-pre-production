using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    //Defines the script as a singleton
    public static TurnManager instance;

    private GameObject activeUnit;

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
	

    void Update()
    {
	
    }


    void TrackPlacement()
    {
        if (UnitManager.inst.GetContentsOfList(1).Count == 3 && UnitManager.inst.GetContentsOfList(2).Count == 3)    //Have all units been placed
        {
            TrackPlayableUnit();
        }
      
    }

    void TrackPlayableUnit()
    {
        activeUnit = UnitManager.inst.player1Units[0];
        var firstUnit = (GameObject)Instantiate(activeUnit, UnitManager.inst.player1Units[1].transform.position, Quaternion.identity);
        UnitManager.inst.player1Units[0].GetComponentInChildren<Camera>().enabled = false;
        UnitManager.inst.player1Units[0].GetComponentInChildren<Camera>().enabled = true;
        //Link to spawn manager script to set the fps camera to the first placed unit

        //then run code from Switch to switch the players turn (After end turn button)
    }
        
}
