using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicoptero : MonoBehaviour
{

    FollowTarget followTarget;

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
}
