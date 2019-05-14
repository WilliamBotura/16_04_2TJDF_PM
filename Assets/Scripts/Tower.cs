using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform spawnPoint;

	void Start () {
		
	}
	
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(projetilPrefab, spawnPoint.position, spawnPoint.transform.rotation);
        }
	}
}
