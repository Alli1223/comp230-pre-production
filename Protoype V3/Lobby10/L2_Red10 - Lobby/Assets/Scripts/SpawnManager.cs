//-----------------------------------------------------------------------------------------------
// Author : Ross Perry 
// Date : 01 / 10 / 2016  
// Description : Provides customised functionality to spawn players in
// Features functions to carry out server/client checks and then spawn them at the relevent times 
//------------------------------------------------------------------------------------------------


using UnityEngine;
using UnityEngine.Networking;
//using UnityEditor;
using System.Collections;

public class SpawnManager : NetworkManager
{

    //Defines the script as a singleton
    public static SpawnManager instance;

    [SerializeField] private GameObject playerObject;

    public bool moveable = false;
    private bool doOnce = false; //Prevent OnServerConnect being called twice

    //Error checking
    private string title;
    private string output;



    //Preliminary checks before connecting to the server/client
    void Awake()
    {
        //EditorUtility.DisplayDialog(title, output, "Have changes been applied and a client built?");

        if (instance != null) 
        {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }

    }
        

    public void OnStartLocalPlayer() //Force enable functionality for the local host
    {

    }
        

    //Called when the "local host" is clicked
    public override void OnServerConnect(NetworkConnection conn)
    {
        
        if (doOnce == false)
        {
            Debug.Log("Server Connected");
            doOnce = true;
            Switch.inst.tactCam.enabled = true;
            //OnServerAddPlayer(conn, 0);
        }
       
    }

    //Called when "client" is clicked
    public override void OnClientConnect(NetworkConnection conn)
    {
        Switch.inst.tactCam.enabled = true;
        Debug.Log("Client Connected");
        //Always become ready / Saves the server asking the player to enable the ready tag
        ClientScene.Ready(conn);
        //Tell the server to spawn a player
        ClientScene.AddPlayer(conn, 0);
    }
        
    //Used in conjunction with "AddPlayerForConnection" to spawn a player into the game
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerObject, GetStartPosition().transform.position, Quaternion.identity);

        //NetworkServer.AddPlayerForConnection(conn, player, playerControllerId:0);

    }

    //Called once the scene has been loaded on the clients
    public override void OnClientSceneChanged(NetworkConnection conn) 
    {
        Switch.inst.tactCam.enabled = true;
        //Always become ready
        ClientScene.Ready(conn);
        //Tell the server to spawn a player
        ClientScene.AddPlayer(client.connection, 0);
    }
        
    //Removes the client when it disconnects to prevent errors, server is handled automatically *WIP*
    public void OnClientDisconnect(NetworkConnection conn, short playerControllerId)
    {
        client.Shutdown();
        NetworkManager.singleton.StopClient();
        Network.Disconnect();
    }
        
 
}
