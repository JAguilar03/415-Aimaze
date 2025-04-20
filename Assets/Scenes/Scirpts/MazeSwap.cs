using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSwap : MonoBehaviour
{

    private GameObject bluecube;
    private GameObject agent;
    private GameObject[] enemies;

    private playermovement pc;
    private playermovement ac;
    private playermovement bc;
    private playermovement ca;
    private playermovement gc;


    // Start is called before the first frame update
    void Start()
    {
        bluecube = GameObject.Find("bluecube");
        DontDestroyOnLoad(bluecube);

        agent = GameObject.Find("Capsule");
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        pc = agent.GetComponent<playermovement>();
        ac = agent.GetComponent<playermovement>();
        bc = agent.GetComponent<playermovement>();
        ca = agent.GetComponent<playermovement>();
        gc = agent.GetComponent<playermovement>();

        DontDestroyOnLoad(agent);
        foreach (GameObject enemy in enemies)
        {
            DontDestroyOnLoad(enemy);
        }

        GameObject[] capsules = GameObject.FindGameObjectsWithTag("Player");
        if (capsules.Length > 1){
            for (int i = 1; i < capsules.Length; i++)
            {
                Destroy(capsules[i]);
            }
        }

        GameObject[] enemiess = GameObject.FindGameObjectsWithTag("enemy");
        if (enemiess.Length > 4){
            for (int i = 4; i < enemiess.Length; i++)
            {
                Destroy(enemiess[i]);
            }
        }

        if (pc != null){
            if (pc.orangeflag){
                Debug.Log("orangeflag is okay");
                GameObject[] orangegates = GameObject.FindGameObjectsWithTag("orange");
                if (orangegates.Length > 0 ){
                    foreach (GameObject x in orangegates){
                        Destroy(x);
                    }
                }
            }
        }
        else{
            Debug.Log("pc does not exist");
        }
        
        if (ac != null){
            if (ac.purpleflag){
                Debug.Log("purpleflag is okay");
                GameObject[] purplegates = GameObject.FindGameObjectsWithTag("purple");
                if (purplegates.Length > 0 ){
                    foreach (GameObject x in purplegates){
                        Destroy(x);
                    }
                }
            }
        }
        else{
            Debug.Log("ac does not exist");
        }

        if (bc != null){
            if (bc.blackflag){
                Debug.Log("blackflag is okay");
                GameObject[] blackgates = GameObject.FindGameObjectsWithTag("black");
                if (blackgates.Length > 0 ){
                    foreach (GameObject x in blackgates){
                        Destroy(x);
                    }
                }
            }
        }
        else{
            Debug.Log("bc does not exist");
        }

        if (ca != null){
            if (ca.cyanflag){
                Debug.Log("cyanflag is okay");
                GameObject[] cyangates = GameObject.FindGameObjectsWithTag("cyan");
                if (cyangates.Length > 0 ){
                    foreach (GameObject x in cyangates){
                        Destroy(x);
                    }
                }
            }
        }
        else{
            Debug.Log("ca does not exist");
        }

        if (gc != null){
            if (gc.greenflag){
                Debug.Log("greenflag is okay");
                GameObject[] greengates = GameObject.FindGameObjectsWithTag("green");
                if (greengates.Length > 0 ){
                    foreach (GameObject x in greengates){
                        Destroy(x);
                    }
                }
            }
        }
        else{
            Debug.Log("gc does not exist");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Scene[] scenes = SceneManager.GetAllScenes();
            int index;
            if (scenes[1].name == "Maze3" || scenes[1].name == "Maze4") {
                index = 1;
            }
            else {
                index = 2;
            }

            if (scenes[index].name == "Maze3") {
                SceneManager.LoadScene("Maze4", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Maze3");
            }
            else if (scenes[index].name == "Maze4") {
                SceneManager.LoadScene("Maze3", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Maze4");
            }
            else {
                Debug.LogError("womp womp");
            }
        }
        
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     Scene[] scenes = SceneManager.GetAllScenes();
        //     if (scenes[0].name == "Maze1") {
        //         SceneManager.LoadScene("Maze2");
        //     }
        //     else if (scenes[0].name == "Maze2") {
        //         SceneManager.LoadScene("Maze1");
        //     }
        //     else if (scenes[0].name == "Maze3") {
        //         SceneManager.LoadScene("Maze4");
        //     }
        //     else if (scenes[0].name == "Maze4") {
        //         SceneManager.LoadScene("Maze3");
        //     }
        //     else {
        //         Debug.Log("ERROR: scene not swapping propperly");
        //     }
        // }

    }
}
