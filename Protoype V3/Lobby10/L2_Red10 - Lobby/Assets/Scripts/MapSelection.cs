using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour {
    
    public Canvas visualRepOfPlayerArea;
    [SerializeField]
    private Canvas UnitSelct, canv;
    public static MapSelection isnt;
  

	// Use this for initialization
	void Start ()
    {
        isnt = this;
        canv.enabled = true;
        UnitSelct.enabled = false;
        DontDestroyOnLoad(this.gameObject);
        visualRepOfPlayerArea.enabled = false;
      


    }

    public void map1()
    {
        SceneManager.LoadScene("Test");
        canv.enabled = false;
        UnitSelct.enabled = true;
        visualRepOfPlayerArea.enabled = true;//may need to change how this is done depending on how ross has done it (probably just load another scene and once done there load a chosen map via a variable)
        DontDestroyOnLoad(UnitSelct);
        
    }
    public void map2()
    {
        SceneManager.LoadScene("map");
        canv.enabled = false;
        UnitSelct.enabled = true;
        visualRepOfPlayerArea.enabled = true;
        DontDestroyOnLoad(UnitSelct);
    }

   

    }

