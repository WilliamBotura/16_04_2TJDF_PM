using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorHelicopteros : MonoBehaviour
{

    public GameObject helicopteroPrefab;
    public float delay = 2f;

	void Start ()
    {
        InvokeRepeating("GerarHelicoptero", delay, delay);
	}
	
	void Update ()
    {
		
	}

    void GerarHelicoptero()
    {
        GameObject helicoptero = Instantiate(helicopteroPrefab);

        int numeroAleatorio = Random.Range(0, 4);

        helicoptero.transform.eulerAngles = Vector3.up * numeroAleatorio * 90;
    }
}
