using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    [Header("Target")]
    public Transform target;
    public string targetTag;
    public bool buscarMaisProximo;

    [Header("Movimento")]
    public float velMovimento = 1.0f;

    [Header("Rotação")]
    public float velRotacao = 1.0f;
    public bool lookAt = false;

	void Start ()
    {
        //
	}
	
	void Update ()
    {
        ProcurarTerget();
        Movimentar();
        Rotacionar();
	}

    private void ProcurarTerget()
    {
        //condições de quabre de método
        if (targetTag == "" || (!buscarMaisProximo && target == null))
        {
            return;
        }

        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        Transform possivelTarget = null;

        foreach (GameObject checarTarget in targets)
        {
            float checarDis = Vector3.Distance(checarTarget.transform.position, transform.position);
            if (possivelTarget == null || (checarDis < Vector3.Distance(possivelTarget.transform.position, transform.position)))
            {
                possivelTarget = checarTarget.transform;
            }
        }
        if (possivelTarget != null)
        {
            target = possivelTarget;
        }
    }

    private void Movimentar()
    {
        // Se a variável lookAt estiver marcada ou se não
        // possuímos uma informação de target, movimentamos
        // em linha reta

        if (lookAt || target == null)
        {
            //Movimento em linha reta
            transform.Translate(Vector3.forward * velMovimento * Time.deltaTime);
        }
        else if (target != null)
        {
            Vector3 direcao = (target.position - transform.position).normalized;
            transform.Translate(direcao * velMovimento * Time.deltaTime, Space.World);
        }
    }

    private void Rotacionar()
    {
        if (lookAt && target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(
                target.position - transform.position), Time.deltaTime * velRotacao);
        }
    }
}
