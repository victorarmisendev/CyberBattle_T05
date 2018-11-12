using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaMovimiento : MonoBehaviour {

    private bool checkMove = true;

	void Start ()
    {	
	}
	
	void Update () {

        if (gameObject.transform.rotation.y > 35.0f)
        {
            checkMove = true;
        }

        if (gameObject.transform.rotation.y < 35.0f)
        {
            checkMove = false;
        }

        if (checkMove)
        {
            transform.Rotate(Vector3.forward, 0.5f);
        }
        else
        {
            transform.Rotate(Vector3.forward, 0.5f);
        }

    }
}
