using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class light : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Maze3", LoadSceneMode.Additive);
        SceneManager.LoadScene("Maze3.2", LoadSceneMode.Additive);
    }

}
