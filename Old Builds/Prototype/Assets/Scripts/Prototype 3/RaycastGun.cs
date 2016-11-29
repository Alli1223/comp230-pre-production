using UnityEngine;
using System.Collections;

public class RaycastGun : MonoBehaviour {

	private Ray mouse;
	private RaycastHit click;
	[SerializeField]
	private Camera firstPerson;
	[SerializeField]
	private ParticleSystem part;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0) && TimeController.instance.isPaused == false)
		{
			mouse = firstPerson.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(mouse, out click))
				{
				Debug.Log ("Hit!");
				if (click.collider.gameObject.tag == "Player2") 
				{
					Debug.Log ("HitotherPLyaer!");
					Debug.DrawLine(mouse.origin, click.point, Color.green);
					//part.Play ();
				}
		    }
		}
		if (Input.GetMouseButton (0) && TimeController.instance.isPaused == false)
		{
			mouse = firstPerson.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(mouse, out click))
			{
				Debug.Log ("Hit!");
				if (click.collider.gameObject.tag == "Player1") 
				{
					Debug.Log ("HitotherPLyaer!");
					Debug.DrawLine(mouse.origin, click.point, Color.red);
				}
			}
		}
	}
}
