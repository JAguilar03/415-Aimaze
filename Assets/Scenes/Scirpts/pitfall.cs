
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportScript : MonoBehaviour
{
    // private NavMeshAgent navMeshAgent;
    private Transform teleportDestination;
    [SerializeField] private GameObject bluecube;
    
    void OnTriggerEnter(Collider other)
    {

        if (bluecube != null)
        {
            teleportDestination = bluecube.transform;
        }
        else
        {
            Debug.LogError("Cannot find object named 'bluecube'.");
        }

        // Assuming this script is attached to the object that needs to teleport,
        // let's also ensure we have a NavMeshAgent component.
        // navMeshAgent = GetComponent<NavMeshAgent>();
        // if (navMeshAgent == null)
        // {
        //     Debug.LogError("NavMeshAgent component is not attached to the object.");
        // }
    

        
        // Check if the triggering object has the name "redcube"
        if ((other.gameObject.name == "redcube" || other.gameObject.name == "RedCapsule" 
            || other.gameObject.name == "RedCapsule2") && teleportDestination != null)
        {
            Debug.Log("Teleporting... Before: " + other.transform.position);
            // navMeshAgent.enabled = false; // Disable the NavMeshAgent before teleporting
            transform.position = bluecube.transform.position; // Teleport the object
            // navMeshAgent.enabled = true; // Re-enable the NavMeshAgent after teleporting
            Debug.Log("Teleported to: " + other.transform.position);
        }
        

    }
}
