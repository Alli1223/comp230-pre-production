using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Author: Kate Georgiou 20/9/16 Description: inventory system that stores items that have been collected and allows for htem to be recalled and used later.
// To use this script can be attached to any game object aslong as the camera to be used is dragged onto the script in the editor.

public class InventorySystem : MonoBehaviour {

    public static InventorySystem instance; //makes the inventory script (singleton) refrencable by other scripts (needed for the recalling items script)
    [SerializeField]
    public List<GameObject> ItemList = new List<GameObject>(); //the list that holds the game objects that have been picked up
    private Ray mouse; 
    private RaycastHit mouseClick;
    [SerializeField]
    private Camera camToUse; //the camera that uses the raycast to select objects via clicking.
	// Use this for initialization
	void Awake()
    {
        instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) //for left clicking
        {
			mouse = camToUse.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast(mouse, out mouseClick))
            {
                if (mouseClick.collider.gameObject.tag == "Object") //any objects tagged as Object can be picked up whilst mouse is hovering over object.
                {
                    ItemList.Add(mouseClick.collider.gameObject); //Add the selected object to the list/inventory
                    mouseClick.collider.GetComponent<MeshRenderer>().enabled = false; //turns off the object picked up mesh instead of making it inactive so that it can be found by the barricade script.
                    mouseClick.collider.GetComponent<Collider>().enabled = false; //turns off collider too.
                    //mouseClick.collider.gameObject.SetActive(false);
                }
            }
        }


	}
}
