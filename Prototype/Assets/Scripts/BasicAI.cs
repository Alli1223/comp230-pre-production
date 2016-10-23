using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {
    private NavMeshAgent self;
    [SerializeField]
    private GameObject target;
	// Use this for initialization
	void Start ()
    {

        self = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        self.destination = target.transform.position;
	}
}
