using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {


    private Vector3 target;
    [SerializeField]
    private int movementSpeed = 2;
    [SerializeField]
    private bool hasReachedTarget = false;
    private Rigidbody self;
    [SerializeField]
    private GameObject window;

    // Use this for initialization
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // self.velocity = transform.forward * movementSpeed;
        transform.position = Vector3.MoveTowards(transform.position, target, (movementSpeed * Time.deltaTime));
    }

    void Update()
    {
       
        if (this.gameObject.tag == "Player1")
        {
            target = CameraTransform.instance.p2CameraPosition.position;
        }
        if (this.gameObject.tag == "Player2")
        {
            target = CameraTransform.instance.p1CameraPosition.position;
        }
        self = GetComponent<Rigidbody>();
         if (this.transform.position == target)
        {
            hasReachedTarget = true;
        }
    }

    IEnumerator Destory()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

}
