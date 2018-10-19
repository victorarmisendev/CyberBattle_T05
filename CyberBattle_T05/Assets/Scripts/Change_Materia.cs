using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Materia : MonoBehaviour {
	
	void Start ()
    {
		
	}
    
	void Update ()
    {
        GetObject();

    }

    private void GetObject()
    {
        RaycastHit hit;
        
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }
    }


}
