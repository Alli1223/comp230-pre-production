using UnityEngine;
using System.Collections;

public class BulletEffect : MonoBehaviour {
    //AUTHOR: KATE GEORGIOU 26/9/16 DESC: WHEN THE FIREBALL HITS THE PLAYER GAME OBJECT IT DESTROYS THE PLAYER AND ITSELF.
    //ALSO ATTACH ONTO FIREBALL PREFAB.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
