using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text energy, health, currentPlayer;
    private Text player;
    private string player1, player2;
 
    // Use this for initialization
    void Start ()
    {
        player1 = "Player 1";
        player2 = "Player 2";
	}
	
	// Update is called once per frame
	void Update ()
    {
        energy.text = "Energy: " + EnergyScript.inst.energy;
        //   health = attach ross health script.
      
        if (EnergyScript.inst.p1 == true)
        {
            currentPlayer.text = "Current Player: " + player1;
        }
        if (EnergyScript.inst.p2 == true)
        {
            currentPlayer.text = "Current Player: " + player2;
        }

    }
}
