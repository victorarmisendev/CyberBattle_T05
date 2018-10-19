using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Properties : MonoBehaviour {

    //El player tiene vida: 100 ( int ) 
    //El player tiene energia: 1500 ( int)
    //Cada acción de cambio de materia cuesta 100 de energia

    private int live;
    private int energy;

    public int GetLive()
    {
        return live;
    }

    public void SetLive(int l)
    {
        live = l;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(int e)
    {
        energy = e;
    }

}
