using UnityEngine;
using System.Collections;

public class PlaceholderAI : MonoBehaviour {

    private GameObject player;
    private float distanceToPlayer;
    private Vector3 toPlayer;
    private Rigidbody rb;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private float speed;
    private bool hasShot = false;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        toPlayer = new Vector3 (player.transform.position.x - this.gameObject.transform.position.x, player.transform.position.y - this.gameObject.transform.position.y, player.transform.position.z - this.gameObject.transform.position.z).normalized;

        if (distanceToPlayer < 6f && !hasShot)
        {
            Instantiate(fireball, this.gameObject.transform.position + toPlayer, Quaternion.identity);
            StartCoroutine(fireballing());
            hasShot = true;
        }
        else if (distanceToPlayer < 6f && hasShot)
        {

        }
        else
        {
            rb.velocity = toPlayer.normalized * speed;
        }
	}

    IEnumerator fireballing()
    {

        yield return new WaitForSeconds(5);
        hasShot = false;
    }
}
