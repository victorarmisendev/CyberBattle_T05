using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour {

    public GameObject bandera;

    private void Start()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Properties>().points++;

            GameObject [] towers = GameObject.FindGameObjectsWithTag("Tower");

            int randomTower = Random.Range(0, towers.Length);

            Instantiate(bandera, towers[randomTower].transform.position + (Vector3.up *
                towers[randomTower].GetComponent<Tower_Procedural>().alturaMaxima), bandera.transform.rotation);

            Destroy(this.gameObject);

        }
    }


}
