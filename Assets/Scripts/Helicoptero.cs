using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicoptero : MonoBehaviour
{
    public float forcaTorque = 200.0f;

    FollowTarget followTarget;

    public GameObject explosionPrefab;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Start ()
    {
        followTarget = GetComponent<FollowTarget>();
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            waypoint Waypoint = other.GetComponent<waypoint>();
            waypoint waypointPosterior = Waypoint.waypointPosterior;
            followTarget.target = waypointPosterior.transform;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Projétil"))
        {
            //print("atingido");
            rb.isKinematic = false;
            rb.useGravity = true;
            Destroy(col.gameObject);

            //instantiate de FX de explosão
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            rb.AddTorque(Vector3.left * forcaTorque);
        }
        else if (col.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
