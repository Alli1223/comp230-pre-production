/* 
 * Aim of this script is to simulate blocking/barricading access
 * 
 * Has player clicked on window/door
 * if player is holding necessary materials in inventory (tagged "Object") for example
 * spawn barricade on the window
 * 
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barricade : MonoBehaviour
{

	public GameObject barricadeObject;
	public Camera cam;
	private Ray ray; 
	private RaycastHit mouseClick;


	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) //Has rightmouse been held down
		{
			ray = cam.ScreenPointToRay (Input.mousePosition);
			CheckList ();
		}
	}

	void CheckList()
	{
		if (Physics.Raycast(ray, out mouseClick))
		{
			if (mouseClick.collider.gameObject.tag == "Window") //Has the player clicked on the window/door
			{
				//GameObject Resource = GameObject.FindWithTag ("Object");
				//Find with tag not working as it checks for active game objects and the inventory script sets the resource as inactive.
				if (InventorySystem.instance.ItemList.Contains(GameObject.FindWithTag("Object"))) //Does list contain barricade object
				{
					SpawnBarricade ();
				}

			}
			else
			{
				return;
			}

		}

	}

	void SpawnBarricade()
	{
		barricadeObject.SetActive (true); //Make barricade appear in scene
	}


}
