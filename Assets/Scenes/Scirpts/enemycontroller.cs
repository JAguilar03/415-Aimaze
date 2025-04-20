using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{
    [SerializeField] private GameObject agent;

    // Adds movePosition as a function when used on the object
    private Transform movePositionTransform;

    // Uses the navmeshagent to move the object
    private NavMeshAgent navMeshAgent;

    public bool orangeflag = false;
    public bool purpleflag = false;
    public bool blackflag = false;
    public bool cyanflag = false;
    public bool greenflag = false;

    private void Start()
    {
        // Gets the navmeshagent component
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Check if the agent is found
        if (agent != null)
        {
            // Set the movePositionTransform to the agent's transform
            movePositionTransform = agent.transform;
        }
        else
        {
            Debug.LogError("agent not found!");
        }

    }

    private void Update()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (movePositionTransform == null){
            movePositionTransform = agent.transform;
        }

        navMeshAgent.destination = movePositionTransform.position;
    }  
    
}
