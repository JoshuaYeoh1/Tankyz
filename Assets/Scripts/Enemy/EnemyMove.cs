using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {   
        if(!player) player = GameObject.FindGameObjectWithTag("Player");

        if(player)
        {
            if(agent.isStopped) agent.isStopped=false;
            agent.SetDestination(player.transform.position);
        }
        else if(!agent.isStopped) agent.isStopped=true;
    }
}
