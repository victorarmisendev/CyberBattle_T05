using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid_Effect : MonoBehaviour {

    private Vector3 volume;
    public Material liquid_Material;

    private void Update()
    {    
    }

    private Vector3 GetVolume()
    {
        return gameObject.GetComponent<Renderer>().bounds.size;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Floor")
        {
            collision.gameObject.GetComponent<Renderer>().material = liquid_Material;
        }
    }


}
