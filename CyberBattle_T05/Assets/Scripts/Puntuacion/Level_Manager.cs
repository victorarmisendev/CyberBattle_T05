using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

    public GameObject player; // Template del jugador
    public int numeroDeJugadores; // Num_ de jugadores

    public GameObject bandera; // Objeto del objetivo
    public Transform primeraLocalizacion; // Posicion del objetivo

    public GameObject[] jugadores; // Alojamiento de todos los jugadores
    public int objective_points; // Puntos para ganar la partida

    public static bool GetObjective = false;
    bool check = false;

    private void Start()
    {

        //for (int i = 0; i < numeroDeJugadores; i++)
        //{
        //    //Instanciamos el jugador en una posicion random
        //    jugadores[i] = Instantiate(jugador_template, transform.position + new Vector3(Random.Range(0, 20), 1,
        //        Random.Range(0, 20)), jugador_template.transform.rotation);

        //    jugadores[i].GetComponent<Player_Properties>().numeroDeJugador = i;
        //    jugadores[i].GetComponent<Player_Properties>().puntos = 0;



        //}

        //Instantiate(objetivo, primeraLocalizacion.position, primeraLocalizacion.rotation);

        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        int randomTower = Random.Range(0, towers.Length);

        Instantiate(bandera, towers[randomTower].transform.position + Vector3.up * 10.0f
            /*towers[randomTower].GetComponent<Tower_Procedural>().alturaMaxima)*/, bandera.transform.rotation);

    }


    public void Update()
    {
        LevelCheck();
    }

    void RestartLevel()
    {
        //for (int i = 0; i < numeroDeJugadores; i++)
        //{
        //Instanciamos el jugador en una posicion random
        //jugadores[i] = Instantiate(jugador_template, transform.position + new Vector3(Random.Range(0, 20), 1,
        //    Random.Range(0, 20)), jugador_template.transform.rotation);

            player.transform.position = new Vector3(Random.Range(0, 20), 1,
            Random.Range(0, 20));

            player.GetComponent<Player_Properties>().numeroDeJugador = 0;
            player.GetComponent<Player_Properties>().puntos = 0;
        //}
    }

    public void LevelCheck()
    {

        if(GetObjective)
        {
            RestartLevel();
            GetObjective = false;
        }
        
        if(Win())
        {
            Finish();
        }
        else
        {
            Debug.Log("Play");
        }

    }

    public bool Win()
    {
        //for (int j = 0; j < numeroDeJugadores; j++)
        //{
            if (player.GetComponent<Player_Properties>().puntos == objective_points)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        //}
        //Debug.Log(check);
        return check;
    }

    public void Finish()
    {
        Debug.Log("FINISH BITCHHH");
    }



}
