using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform spawnPoint;
	// Use this for initialization
	void Start ()
    {
	  
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F) && UniSelect.inst.selectedObject !=null && TimeController.instance.isPaused == false)
        {
            //instnatiate.
            Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
        }
    }
}
