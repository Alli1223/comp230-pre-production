using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonScripts : MonoBehaviour {
    //AUTHOR: KATE GEORGIOU 21/9/16 DESC: when the buttons on the inventory is pressed then it will retrieve the item stored in the inventory slot number.
    //Attach this script to the buttons (one on each button) and manually add the slot number on the button in on the editor (start at 0 for the first one). Then select the 'SpawnItem' fucntion in the editor in the OnClick() section.


    [SerializeField]
    private int slotNumber; //an int representing the number in the list that the object is being held in.
    private GameObject Player; //refrences the game object for the player so that the game object can be spawned on the player.

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //retrieves player object based on the tag so make sure to tag the player as 'Player' and pickup objects as 'Objects'.
    }
    public void SpawnItem()
    {
        //Spawn from the location in the list
       GameObject spawnedItem = Instantiate(InventorySystem.instance.ItemList[slotNumber], Player.transform.position, Player.transform.rotation) as GameObject;
        //Set the object as active
        spawnedItem.SetActive(true);
        //Remove the item from the list
        InventorySystem.instance.ItemList.Remove(InventorySystem.instance.ItemList[slotNumber]);
    }
}
