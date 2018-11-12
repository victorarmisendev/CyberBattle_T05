using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Escaleras")
        {

            gameObject.GetComponent<Rigidbody>().useGravity = false;
            

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * 0.05f;
            }

            if(Input.GetKey(KeyCode.S))
            {
                transform.position -= Vector3.up * 0.05f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

}
