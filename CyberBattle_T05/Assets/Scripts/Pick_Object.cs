using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Object : MonoBehaviour {

    public float offset;
    private Vector3 previous_pos;
    public Camera cam_player;

    private void Update()
    {
        PickObject();
    }

    private void PickObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam_player.transform.position, cam_player.transform.forward, out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.tag != "Floor")
            {                
                hit.collider.gameObject.transform.position = cam_player.transform.right * offset + new Vector3(0, 1, 0);
                hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Debug.Log(cam_player.transform.forward);
            }
        }
    }

}
