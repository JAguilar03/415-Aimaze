using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "greencube")
        {
            if (gameObject.name == "Capsule") {
                SceneManager.LoadScene("p1win");
            }
            else if (gameObject.name == "Capsule2") {
                SceneManager.LoadScene("p2win");
            }
            else {
                SceneManager.LoadScene("winner");
            }
        }
        // if (collision.gameObject.name == "RedCapsule" || collision.gameObject.name == "RedCapsule2")
        // {
        //     SceneManager.LoadScene("loser");
        // }
    }

}
