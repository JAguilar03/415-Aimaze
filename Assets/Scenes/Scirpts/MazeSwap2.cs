using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSwap2 : MonoBehaviour
{
    private GameObject bluecube2;
    private GameObject agent2;
    private GameObject[] enemies2;

    private playermovement22 pc;
    private playermovement22 ac;
    private playermovement22 bc;
    private playermovement22 ca;
    private playermovement22 gc;


    // Start is called before the first frame update
    void Start()
    {
        bluecube2 = GameObject.Find("bluecube2");
        DontDestroyOnLoad(bluecube2);

        agent2 = GameObject.Find("Capsule2");
        enemies2 = GameObject.FindGameObjectsWithTag("enemy2");

        pc = agent2.GetComponent<playermovement22>();
        ac = agent2.GetComponent<playermovement22>();
        bc = agent2.GetComponent<playermovement22>();
        ca = agent2.GetComponent<playermovement22>();
        gc = agent2.GetComponent<playermovement22>();

        DontDestroyOnLoad(agent2);
        foreach (GameObject enemy2 in enemies2)
        {
            DontDestroyOnLoad(enemy2);
        }

        GameObject[] capsules = GameObject.FindGameObjectsWithTag("Player2");
        if (capsules.Length > 1){
            for (int i = 1; i < capsules.Length; i++)
            {
                Destroy(capsules[i]);
            }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy2");
        if (enemies.Length > 4){
            for (int i = 4; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
        }

        if (pc != null){
            if (pc.orangeflag2){
                Debug.Log("orangeflag is okay");
                GameObject[] orangegates = GameObject.FindGameObjectsWithTag("orange2");
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
            if (ac.purpleflag2){
                Debug.Log("purpleflag is okay");
                GameObject[] purplegates = GameObject.FindGameObjectsWithTag("purple2");
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
            if (bc.blackflag2){
                Debug.Log("blackflag is okay");
                GameObject[] blackgates = GameObject.FindGameObjectsWithTag("black2");
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
            if (ca.cyanflag2){
                Debug.Log("cyanflag is okay");
                GameObject[] cyangates = GameObject.FindGameObjectsWithTag("cyan2");
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
            if (gc.greenflag2){
                Debug.Log("greenflag is okay");
                GameObject[] greengates = GameObject.FindGameObjectsWithTag("green2");
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
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            Scene[] scenes = SceneManager.GetAllScenes();
            int index;
            if (scenes[1].name == "Maze3.2" || scenes[1].name == "Maze4.2") {
                index = 1;
            }
            else {
                index = 2;
            }

            if (scenes[index].name == "Maze3.2") {
                SceneManager.LoadScene("Maze4.2", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Maze3.2");
            }
            else if (scenes[index].name == "Maze4.2") {
                SceneManager.LoadScene("Maze3.2", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Maze4.2");
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
