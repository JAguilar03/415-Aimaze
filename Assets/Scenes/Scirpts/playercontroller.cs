using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontroller : MonoBehaviour
{
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

        // Find the GameObject named "greencube"
        GameObject greenCube = GameObject.Find("greencube");

        // Check if the greencube is found
        if (greenCube != null)
        {
            // Set the movePositionTransform to the greencube's transform
            movePositionTransform = greenCube.transform;
        }
        else
        {
            Debug.LogError("Greencube not found!");
        }



        DontDestroyOnLoad(greenCube);

    }

    private void Update()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (movePositionTransform == null){
            GameObject greenCube = GameObject.Find("greencube");
            movePositionTransform = greenCube.transform;
        }

        navMeshAgent.destination = movePositionTransform.position;
    }

 
    void OnTriggerEnter(Collider other)
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GameObject agent = GameObject.Find("Capsule");
        GameObject enemy = GameObject.Find("RedCapsule");
        GameObject bluecube = GameObject.Find("bluecube");
        GameObject greenCube = GameObject.Find("greencube");
        GameObject greenGate = GameObject.Find("greengate");
        GameObject orangegate = GameObject.Find("orangegate");
        GameObject orangecube = GameObject.Find("orangecube");
        GameObject purplecube = GameObject.Find("purplecube");
        GameObject purplegate = GameObject.Find("purplegate");
        GameObject blackcube = GameObject.Find("blackcube");
        GameObject blackgate = GameObject.Find("blackgate");
        GameObject cyancube = GameObject.Find("cyancube");
        GameObject cyangate = GameObject.Find("cyangate");
        // doing your mom
        
        if (other.gameObject.name == "orangecube")
        {
            orangeflag = true;
            Destroy(orangegate.gameObject); 
            movePositionTransform = greenCube.transform;
            
            navMeshAgent.enabled = false; // Disable the NavMeshAgent
           // navMeshAgent.destination = movePositionTransform.position;
            navMeshAgent.enabled = true; // Disable the NavMeshAgent

            Destroy(orangecube);
         }
   
        if (other.gameObject.name == "orangegate" && !orangeflag) // Check if orangeflag condition is necessary for your logic
        {
            movePositionTransform = GameObject.Find("orangecube").transform; // Directly find and set the orangecube as the target
            navMeshAgent.enabled = false; // Temporarily disable the NavMeshAgent to update its destination
            navMeshAgent.enabled = true; // Re-enable the NavMeshAgent
        }
        else {
        
            //DontDestroyOnLoad(orangecube);

        }
      

        if (other.gameObject.name == "purplecube")
        {
            purpleflag = true;
            Destroy(purplegate.gameObject); 
            movePositionTransform = greenCube.transform;
            
            navMeshAgent.enabled = false; // Disable the NavMeshAgent
           // navMeshAgent.destination = movePositionTransform.position;
            navMeshAgent.enabled = true; // Disable the NavMeshAgent

            Destroy(purplecube);
         }
    
       
        if (other.gameObject.name == "purplegate" && !purpleflag) // Check if orangeflag condition is necessary for your logic
        {
            movePositionTransform = GameObject.Find("purplecube").transform; // Directly find and set the orangecube as the target
            navMeshAgent.enabled = false; // Temporarily disable the NavMeshAgent to update its destination
            navMeshAgent.enabled = true; // Re-enable the NavMeshAgent
        }
        else {
  
            //DontDestroyOnLoad(purplecube);

        }



        if (other.gameObject.name == "blackcube")
        {
            blackflag = true;
            Destroy(blackgate.gameObject); 
            movePositionTransform = greenCube.transform;
            
            navMeshAgent.enabled = false; // Disable the NavMeshAgent
           // navMeshAgent.destination = movePositionTransform.position;
            navMeshAgent.enabled = true; // Disable the NavMeshAgent

            Destroy(blackcube);
         }
    
       
        if (other.gameObject.name == "blackgate" && !blackflag) // Check if orangeflag condition is necessary for your logic
        {
            movePositionTransform = GameObject.Find("blackcube").transform; // Directly find and set the orangecube as the target
            navMeshAgent.enabled = false; // Temporarily disable the NavMeshAgent to update its destination
            navMeshAgent.enabled = true; // Re-enable the NavMeshAgent
        }
        else {

            //DontDestroyOnLoad(blackcube);

        }
         

        if (other.gameObject.name == "cyancube")
        {
            cyanflag = true;
            Destroy(cyangate.gameObject); 
            movePositionTransform = greenCube.transform;
            
            navMeshAgent.enabled = false; // Disable the NavMeshAgent
           // navMeshAgent.destination = movePositionTransform.position;
            navMeshAgent.enabled = true; // Disable the NavMeshAgent

            Destroy(cyancube);
         }
    
       
        if (other.gameObject.name == "cyangate" && !cyanflag) // Check if orangeflag condition is necessary for your logic
        {
            movePositionTransform = GameObject.Find("cyancube").transform; // Directly find and set the orangecube as the target
            navMeshAgent.enabled = false; // Temporarily disable the NavMeshAgent to update its destination
            navMeshAgent.enabled = true; // Re-enable the NavMeshAgent
        }
        else {
  
            //DontDestroyOnLoad(cyancube);

        }

        // check if greengate is collided and checks flags to 
        if (other.gameObject.name == "greengate" && !greenflag 
                && orangeflag && purpleflag && blackflag && cyanflag)
        {
            greenflag = true;
            Destroy(greenGate);
        }
        else if(other.gameObject.name == "greengate" && !greenflag)
        {
            Debug.Log("Teleporting... Before: " + agent.transform.position);
            navMeshAgent.enabled = false; // Disable the NavMeshAgent before teleporting
            agent.transform.position = bluecube.transform.position; // Teleport the object
            navMeshAgent.enabled = true; // Re-enable the NavMeshAgent after teleporting
            Debug.Log("Teleported to: " + agent.transform.position);
        }

    }
    
}
