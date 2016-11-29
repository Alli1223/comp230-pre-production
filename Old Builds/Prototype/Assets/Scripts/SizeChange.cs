using UnityEngine;
using System.Collections;

public class SizeChange : MonoBehaviour {
    //AUTHOR: KATE GEORGIOU 26/9/16 DESC: WHEN E IS PRESSED ANY OBJECTS WITH THE ABILITY TO WILL GROW TO WHATEVER THE INPUTTED SIZE IS AND THEN ON PRESS AGAIN IT RETURNS TO DEFAULT SIZE.
    //WHEN Q IS PRESSED THE OBJECTS SHRINK AND THEN WHEN Q IS PRESSED AGAIN IT ALSO RETURNS TO DEFAULT SIZE.
    //TO USE: ATTACH TO OBJECT (UNLESS ALREADY PRESENT) AND THEN IN THE INSPECTOR ADD THE VALUES THAT U WANT TO INCREASE THE OBKECT BY.
    [SerializeField]
    private Vector3 SizetoInc, SizeToSmall, defaultSize;
    private bool Changeable;

	// Use this for initialization
	void Start ()
    {
        defaultSize = this.gameObject.transform.localScale;
        Changeable = true;
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Changeable == true)
        {
            this.gameObject.transform.localScale = SizetoInc;
            Changeable = false;
        }
       else if (Input.GetKeyDown(KeyCode.E) && Changeable == false)
        {
            defSize();
        }
        if (Input.GetKeyDown(KeyCode.Q) && Changeable == true)
        {
            this.gameObject.transform.localScale = SizeToSmall;
            Changeable = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && Changeable == false)
        {
            defSize();
        }
	
	}
    void defSize()
    {
        this.gameObject.transform.localScale = defaultSize;
        Changeable = true;
    }
}
