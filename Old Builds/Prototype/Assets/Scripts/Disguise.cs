using UnityEngine;
using System.Collections;
//AUTHOR: KATE GEORGIOU 26/9 DESC: CHANGES THE COLOUR OF THE PLAYER OBJECT IN ORDER TO ACTIVATE CAMO MODE (IN THE FIREBALL EFFECT SCRIPT)
//TO USE: ATTACH TO PLAYER GAME OBJECT.

public class Disguise : MonoBehaviour {
    public bool isCamo = false;
    public static Disguise instance;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isCamo == false)
        {
            Renderer myRenderer = gameObject.GetComponent<Renderer>();
            myRenderer.material.color = Color.blue;
            isCamo = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCamo == true)
        {
            Renderer myRenderer = gameObject.GetComponent<Renderer>();
            myRenderer.material.color = Color.red;
            isCamo = false;
        }
    }
}
