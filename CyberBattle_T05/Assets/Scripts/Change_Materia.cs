using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Materia : MonoBehaviour {

    public GameObject particle_obj;
    float RAN_X, RAN_Y, RAN_Z;

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
                float NUM_PARTICLES = hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices.Length;

                Destroy(hit.collider.gameObject);

                if(NUM_PARTICLES > 100)
                {
                    NUM_PARTICLES = 100;
                }

                for (int i = 0; i < NUM_PARTICLES; i++)
                {
                    particle_obj = Instantiate(particle_obj, hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices[i] + 
                        hit.collider.gameObject.transform.position,
                        hit.collider.gameObject.transform.rotation) as GameObject;

                    //Debug.Log(hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices[i]);

                    Vector3 particel_Pos = hit.collider.gameObject.GetComponent<MeshFilter>().mesh.vertices[i];

                    float RAN_X = Random.Range(-particel_Pos.x, particel_Pos.x + 1);
                    float RAN_Y = Random.Range(-particel_Pos.x, particel_Pos.x + 1);
                    float RAN_Z = Random.Range(-particel_Pos.x, particel_Pos.x + 1);

                    particle_obj.GetComponent<Rigidbody>().AddForce(new Vector3(RAN_X, RAN_Y, RAN_Z), ForceMode.Impulse);

                }

                //Debug.Log(NUM_PARTICLES);


            }
        }
    }


}
