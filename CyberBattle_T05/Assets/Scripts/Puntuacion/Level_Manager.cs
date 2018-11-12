using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

    //public GameObject jugador_template; // Template del jugador
    //public int numeroDeJugadores; // Num_ de jugadores
    
    public GameObject bandera; // Objeto del objetivo
    //public Transform primeraLocalizacion; // Posicion del objetivo

    //public GameObject[] jugadores; // Alojamiento de todos los jugadores
    //public int objective_points; // Puntos para ganar la partida

    private void Start()
    {

        //for (int i = 0; i < numeroDeJugadores; i++)
        //{
        //    //Instanciamos el jugador en una posicion random
        //    jugadores[i] = Instantiate(jugador_template, transform.position + new Vector3(Random.Range(0, 20), 1, 
        //        Random.Range(0, 20)), jugador_template.transform.rotation);

        //    jugadores[i].GetComponent<Player_Properties>().playerNumber = i;
        //    jugadores[i].GetComponent<Player_Properties>().points = 0;



        //}

        //Instantiate(objetivo, primeraLocalizacion.position, primeraLocalizacion.rotation);

        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        int randomTower = Random.Range(0, towers.Length);

        Instantiate(bandera, towers[randomTower].transform.position + (Vector3.up *
            towers[randomTower].GetComponent<Tower_Procedural>().alturaMaxima), bandera.transform.rotation);

    }


    public void Update()
    {
        
    }

    public void LevelCheck()
    {
        //while(Win() == false)
        //{

        //}
    }

    //public bool Win()
    //{
    //    bool check = false;
    //    for (int j = 0; j < numeroDeJugadores; j++)
    //    {
    //        if(jugadores[j].GetComponent<Player_Properties>().points != objective_points)
    //        {
    //            check = false;
    //        }
    //        else
    //        {
    //            check = true;
    //        }
    //    }
    //    return check;
    //}



}
