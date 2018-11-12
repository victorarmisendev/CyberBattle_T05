using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Procedural : MonoBehaviour {

    public GameObject [] props;
    public GameObject [] suelos;
    public GameObject Tower_Box;
    private float alturaPorNivel;
    public int numeroDeNiveles;
    public int propsPorNivel;
    public GameObject[] vigas;
    public GameObject viga_Prefab;
    public GameObject grua, escaleras_ext;

    public Texture brick_tex;
    public Texture normal_tex;

    private float[] fixedAngles;
    private float[] grua_pos = new float[2];
    

    public Color[] coloresDePlataforma;
    public Vector3 boundsSize;

    public float alturaMaxima;

	void Start ()
    {
        boundsSize = Tower_Box.GetComponent<Renderer>().bounds.size
            / 2;

        fixedAngles = new float[5];

        fixedAngles[0] = 0;
        fixedAngles[1] = 90;
        fixedAngles[2] = 180;
        fixedAngles[3] = 270;
        fixedAngles[4] = 360;

        grua_pos[0] = -Tower_Box.GetComponent<Renderer>().bounds.size.x / 2;
        grua_pos[1] = Tower_Box.GetComponent<Renderer>().bounds.size.x / 2;

        alturaPorNivel = alturaMaxima / numeroDeNiveles;

        for (int i = 0; i < numeroDeNiveles; i++)
        {
            for (int j = 0; j < propsPorNivel; j++)
            {
                Vector3 randomPosition = new Vector3(Tower_Box.transform.position.x +
                    Random.Range(-boundsSize.x, boundsSize.x), i * alturaPorNivel + 2.0f, Tower_Box.transform.position.z +
                    Random.Range(-boundsSize.z, boundsSize.z));
             
                GameObject plataforma = Instantiate(props[Random.Range(0, props.Length)], randomPosition,
                    props[0].transform.rotation );

                plataforma.transform.Rotate(Vector3.forward, Random.Range(0, 360));

                int randomColor = Random.Range(0, coloresDePlataforma.Length);

                plataforma.GetComponent<Renderer>().material.color =
                    coloresDePlataforma[randomColor];

                //plataforma.GetComponent<Renderer>().material.SetTexture("Brick", brick_tex);

            }
        }


        for (int u = 1; u < numeroDeNiveles + 1; u++)
        {
            Vector3 randomPositionSuelo = new Vector3(Tower_Box.transform.position.x, u * alturaPorNivel,Tower_Box.transform.position.z);

            GameObject suelo = Instantiate(suelos[Random.Range(0, suelos.Length - 1)], randomPositionSuelo,
                suelos[0].transform.rotation);

            suelo.transform.Rotate(Vector3.forward, fixedAngles[Random.Range(0, fixedAngles.Length - 1)]);

            int randomColor2 = Random.Range(0, coloresDePlataforma.Length);

            suelo.GetComponent<Renderer>().material.color =
                coloresDePlataforma[randomColor2];

            suelo.transform.localScale = new Vector3(1, 1, 1);


            //suelo.GetComponent<Renderer>().material.SetTexture("_MainTex", brick_tex);
            //suelo.GetComponent<Renderer>().material.SetTexture("_BumpMap", normal_tex);
            //suelo.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(6.0f, 6.0f));
            //suelo.GetComponent<Renderer>().material.SetTextureScale("_BumpMap", new Vector2(6.0f, 6.0f));
        }

        for (int u = 1; u < numeroDeNiveles + 1; u++)
        {

            float randomGrua = grua_pos[Random.Range(0, 2)];
            Vector3 randomPosition = new Vector3(Tower_Box.transform.position.x + randomGrua, u * alturaPorNivel,
                Tower_Box.transform.position.z);
            GameObject grua_obj = Instantiate(grua, randomPosition, grua.transform.rotation);

            if (randomGrua < 0.0f)
            {
                //grua_obj.transform.Rotate(Vector3.forward, 180.0f);
                grua_obj.transform.localRotation = new Quaternion(grua_obj.transform.localRotation.x, grua_obj.transform.localRotation.y,
                    grua_obj.transform.localRotation.z + 180.0f, 1.0f);

            }
            int randomColor2 = Random.Range(0, coloresDePlataforma.Length);
            grua_obj.GetComponent<Renderer>().material.color = coloresDePlataforma[randomColor2];

            Vector3 randomPosition2 = new Vector3(Tower_Box.transform.position.x + Random.Range(grua_pos[0], grua_pos[1]), u * alturaPorNivel,
                 Tower_Box.transform.position.z + randomGrua);

            GameObject esc_ext = Instantiate(escaleras_ext, randomPosition2, escaleras_ext.transform.rotation);

            esc_ext.transform.Rotate(Vector3.right, 90.0f);

            int randomColor3 = Random.Range(0, coloresDePlataforma.Length);
            esc_ext.GetComponent<Renderer>().material.color = coloresDePlataforma[randomColor3];





        }

        

        //Get vigas
        Vigas();

    }


    void Vigas()
    {

        //Viga 1
     
        Vector3 esquinaIz = Tower_Box.transform.position - (Vector3.right * boundsSize.x) + 
            (Vector3.forward * boundsSize.z);
        Vector3 pos = esquinaIz + new Vector3(0, alturaMaxima/2, 0);
        GameObject viga = Instantiate(viga_Prefab, pos, viga_Prefab.transform.rotation);

        viga.transform.localScale = new Vector3(2, alturaMaxima, 2);
        viga.GetComponent<Renderer>().material.color = Color.red;


        //Viga 2

        Vector3 esquinaDe = Tower_Box.transform.position + (Vector3.right * boundsSize.x) +
            (Vector3.forward * boundsSize.z);
        Vector3 pos2 = esquinaDe + new Vector3(0, alturaMaxima / 2, 0);
        GameObject viga2 = Instantiate(viga_Prefab, pos2, viga_Prefab.transform.rotation);

        viga2.transform.localScale = new Vector3(2, alturaMaxima, 2);
        viga2.GetComponent<Renderer>().material.color = Color.blue;

        //Viga 3

        Vector3 esquinaSuIz = Tower_Box.transform.position - (Vector3.right * boundsSize.x) -
            (Vector3.forward * boundsSize.z);
        Vector3 pos3 = esquinaSuIz + new Vector3(0, alturaMaxima / 2, 0);
        GameObject viga3 = Instantiate(viga_Prefab, pos3, viga_Prefab.transform.rotation);

        viga3.transform.localScale = new Vector3(2, alturaMaxima, 2);
        viga3.GetComponent<Renderer>().material.color = Color.green;

        //Viga 4

        Vector3 esquinaSuDe = Tower_Box.transform.position + (Vector3.right * boundsSize.x) -
            (Vector3.forward * boundsSize.z);
        Vector3 pos4 = esquinaSuDe + new Vector3(0, alturaMaxima / 2, 0);
        GameObject viga4 = Instantiate(viga_Prefab, pos4, viga_Prefab.transform.rotation);

        viga4.transform.localScale = new Vector3(2, alturaMaxima, 2);
        viga4.GetComponent<Renderer>().material.color = Color.yellow;



    }

}
