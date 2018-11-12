using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public Text live;
    public Text DistanceToTarget;
    public Text points;
    public GameObject player;
    GameObject bandera;

    void Awake()
    {
        bandera = new GameObject();
        
    }

	void Update ()
    {
        bandera = GameObject.FindGameObjectWithTag("Bandera");
        live.text = "Vida: " + player.GetComponent<Player_Properties>().vida.ToString();
        points.text = "Puntos: " + player.GetComponent<Player_Properties>().puntos.ToString();
        DistanceToTarget.text = Vector3.Distance(player.transform.position, bandera.transform.position).ToString();
        //Debug.Log(Vector3.Distance(player.transform.position, bandera.transform.position));
    }
}
