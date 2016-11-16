using UnityEngine;
using System.Collections;

public class UnitPlacement : MonoBehaviour
{
    public static bool allUnitsPlaced = false;
    [SerializeField]
    private GameObject player1UnitsToPlace, player2UnitsToPlace;
    private bool p1CanPlace = false;
    private bool p2CanPlace = false;
    private int p1Counter = 0;
    private int p2Counter = 0;
    private Ray mouse;
    private RaycastHit click;
    [SerializeField]
    private Camera tactCam;

    void Start()
    {
        tactCam = this.gameObject.GetComponent<Camera>();
        p1CanPlace = true;
        p2CanPlace = true;
    }

    void Update()
    {
        if (p1Counter >= 3)
        {
            p1CanPlace = false;
        }
        if (p2Counter >= 3)
        {
            p2CanPlace = false;
        }
     

        if (Input.GetMouseButtonDown(0)) //left click
        {
            
            mouse = tactCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouse, out click))
            {
                if (p1CanPlace == true)
                {
                    if (click.collider.gameObject.tag == "P1Area") //have the floor made of several different components that have different tags so if the player clicks on their area their unit is put down?
                    {
                        Instantiate(player1UnitsToPlace, click.point, Quaternion.identity); //instantiate the player 1 game object
                        p1Counter++;
                    }
                 
                }

                if (p2CanPlace == true)
                {
                    if (click.collider.gameObject.tag == "P2Area") //have the floor made of several different components that have different tags so if the player clicks on their area their unit is put down?
                    {
                        Instantiate(player2UnitsToPlace, click.point, Quaternion.identity);
                        p2Counter++;
                    }

                }


            } 
                
        }
            
    }

}
