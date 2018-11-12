using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Properties : MonoBehaviour {

    //El player tiene vida: 100 ( int ) 
    //El player tiene energia: 1500 ( int)
    //Cada acción de cambio de materia cuesta 100 de energia

    public int vida;
    public int energia;
    public int puntos;
    public int numeroDeJugador;

    private void Start()
    {
        SetLive(100);
        SetEnergy(100);
        SetPoints(0);

    }

    public int GetLive()
    {
        return vida;
    }

    public void SetLive(int l)
    {
        vida = l;
    }

    public int GetEnergy()
    {
        return energia;
    }

    public void SetEnergy(int e)
    {
        energia = e;
    }

    public void SetPoints(int p)
    {
        puntos = p;
    }

}
