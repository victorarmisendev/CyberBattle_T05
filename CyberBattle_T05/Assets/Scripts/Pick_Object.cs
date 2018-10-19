using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Object : MonoBehaviour {

    public float offset;
    private Vector3 previous_pos;
    public Camera cam_player;
    private bool hold = false;

    private void Update()
    {
        PickObject();
    }


    private void PickObject()
    {
  
        RaycastHit hit;
        GameObject obj = new GameObject();
        
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(cam_player.transform.position, cam_player.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                    obj = hit.collider.gameObject;
                    hit.collider.gameObject.transform.position = cam_player.transform.forward * offset + new Vector3(0, 1, 0);
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    previous_pos = hit.collider.gameObject.transform.position;                  
            }
        }

        else
        {
            obj.transform.position = previous_pos;
        }

    }

}
