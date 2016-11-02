using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class UniSelect : MonoBehaviour
{

    public static UniSelect inst;
    private Ray mouse;
    private RaycastHit click;
    [SerializeField]
    private Camera TactcamUse;
    public bool p1Selected = false, p2Selected = false;

    public GameObject selectedObject;

    void Awake()
    {
        inst = this;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouse = TactcamUse.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouse, out click))
            {
                if (click.collider.gameObject.tag == "Player1" && EnergyScript.inst.p1 == true)
                {
                    //p1Selected = true;
                    //p2Selected = false;

                    Debug.Log("Selected1");
                    selectedObject = click.collider.gameObject;
                    CameraSwtiching.inst.locationTogoto = click.collider.gameObject.transform.position;
                    CameraSwtiching.inst.FirstPersonCam.transform.position = CameraSwtiching.inst.locationTogoto;



                }
                if (click.collider.gameObject.tag == "Player2"&& EnergyScript.inst.p2 == true)
                {
                    Debug.Log("I AM SELECT");
                    //p2Selected = true;
                   // p1Selected = false;
                    selectedObject = click.collider.gameObject;
                    CameraSwtiching.inst.locationTogoto = click.collider.gameObject.transform.position;
                    CameraSwtiching.inst.FirstPersonCam.transform.position = CameraSwtiching.inst.locationTogoto;
                }
            }
        }
    }
}
