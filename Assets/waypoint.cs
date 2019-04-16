using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class waypoint : MonoBehaviour {

    [Header("Waypoints")]
    [Tooltip("Lista com todos os waypoints")]
    private waypoint[] waypoints;

    private int indexAtual = -1;

    private waypoint waypointAnterior;
    private waypoint waypointPosterior;

	void Start ()
    {
        CarregarSistemasWaypoints();
	}

    

    private void CarregarSistemasWaypoints()
    {
        AtualizarWaypointAtual();
        AtualizarWaypoint();
        LinkarWaypoints();
    }

    private void AtualizarWaypointAtual()
    {
        indexAtual = PegarIdWaypoint(gameObject.name);
    }

    //Completo
    private int PegarIdWaypoint(string name)
    {
        name = name.Replace("Waypont (", "");
        name = name.Replace(")", "");

        int id = -1;

        try
        {
            id = int.Parse(name) - 1;
        }
        catch (Exception)
        {
            Debug.LogError("Algum erro ocorreu. Certifique-se que o Waypoint possui um nome padrão");
        }

        return id;

        
    }

    //Completo
    private void AtualizarWaypoint()
    {
        waypoints = FindObjectsOfType<waypoint>();
        //organiza os waypoints em forma numerica cescente.
        waypoints = waypoints.OrderBy(objeto => PegarIdWaypoint(objeto.name)).ToArray();

    }

    //Completo
    private void LinkarWaypoints()
    {
        int indexAnterior = indexAtual - 1;
        int indexPosterior = indexAtual + 1;

        DefinirWaypoint(ref waypointAnterior, indexAnterior);
        DefinirWaypoint(ref waypointPosterior, indexPosterior);
    }

    //Completo
    private void DefinirWaypoint(ref waypoint waypoint, int index)
    {
        if (index < 0)
        {
            index = waypoints.Length - 1;
        }
        else if (index == waypoints.Length)
        {
            index = 0;
        }

        waypoint = waypoints[index];
    }

    void Update()
    {

    }

    void OnDrawGizmos()
    {
        CarregarSistemasWaypoints();

        if (waypointPosterior != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, waypointPosterior.transform.position);
        }
    }
}
