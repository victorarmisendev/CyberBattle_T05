using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Procedural : MonoBehaviour {

    public GameObject [] props;
    public GameObject Tower_Box;
    private float alturaPorNivel;
    public int numeroDeNiveles;
    public int propsPorNivel;
    public GameObject[] vigas;

    public Color[] coloresDePlataforma;
    public Vector3 boundsSize;

    public float alturaMaxima;

	void Start ()
    {
        boundsSize = Tower_Box.GetComponent<Renderer>().bounds.size
            / 2;

        alturaPorNivel = alturaMaxima / numeroDeNiveles;

        for (int i = 0; i < numeroDeNiveles; i++)
        {
            for (int j = 0; j < propsPorNivel; j++)
            {
                Vector3 randomPosition = new Vector3(Tower_Box.transform.position.x +
                    Random.Range(-boundsSize.x, boundsSize.x), i * alturaPorNivel, Tower_Box.transform.position.z +
                    Random.Range(-boundsSize.z, boundsSize.z));

                //Quaternion randomRotation = new Quaternion(props[0].transform.localRotation.x, 0.0f, 0,1);

                GameObject plataforma = Instantiate(props[Random.Range(0, props.Length)], randomPosition,
                    props[0].transform.rotation * new Quaternion(0,Random.Range(0,360),0,1));

                int randomColor = Random.Range(0, coloresDePlataforma.Length);

                plataforma.GetComponent<Renderer>().material.color =
                    coloresDePlataforma[randomColor];
            }
        }

        //Get vigas
        Vigas();

    }


    void Vigas()
    {
        //Viga 1
        Vector3 esquinaIz = Tower_Box.transform.position - (Vector3.right * boundsSize.x) + 
            (Vector3.forward * boundsSize.z);

        vigas[0].transform.position = esquinaIz + new Vector3(0, alturaMaxima/2, 0);
        vigas[0].transform.localScale = new Vector3(2, alturaMaxima, 2);
        vigas[0].GetComponent<Renderer>().material.color = Color.red;


        //Viga 2
        Vector3 esquinaDe = Tower_Box.transform.position + (Vector3.right * boundsSize.x) +
            (Vector3.forward * boundsSize.z);

        vigas[1].transform.position = esquinaDe + new Vector3(0, alturaMaxima / 2, 0);
        vigas[1].transform.localScale = new Vector3(2, alturaMaxima, 2);
        vigas[1].GetComponent<Renderer>().material.color = Color.blue;


        //Viga 3

        Vector3 esquinaSuIz = Tower_Box.transform.position - (Vector3.right * boundsSize.x) -
            (Vector3.forward * boundsSize.z);

        vigas[2].transform.position = esquinaSuIz + new Vector3(0, alturaMaxima / 2, 0);
        vigas[2].transform.localScale = new Vector3(2, alturaMaxima, 2);
        vigas[2].GetComponent<Renderer>().material.color = Color.green;


        //Viga 4
        int randomColor4 = Random.Range(0, coloresDePlataforma.Length);
        Vector3 esquinaSuDe = Tower_Box.transform.position + (Vector3.right * boundsSize.x) -
            (Vector3.forward * boundsSize.z);

        vigas[3].transform.position = esquinaSuDe + new Vector3(0, alturaMaxima / 2, 0);
        vigas[3].transform.localScale = new Vector3(2, alturaMaxima, 2);
        vigas[3].GetComponent<Renderer>().material.color = Color.yellow;


    }

}
