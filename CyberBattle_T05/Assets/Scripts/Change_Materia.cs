using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Materia : MonoBehaviour {

    public GameObject particle_obj;
    
	void FixedUpdate ()
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
                hit.collider.gameObject.GetComponent<Renderer>().material.color = 
                    Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

                float NUM_PARTICLES = hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices.Length;

                Destroy(hit.collider.gameObject);

                for (int i = 0; i < NUM_PARTICLES; i++)
                {
                    particle_obj = Instantiate(particle_obj, hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices[i],
                        hit.collider.gameObject.transform.rotation) as GameObject;
                    particle_obj.transform.position = hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices[i];
                }



            }
        }
    }


}
