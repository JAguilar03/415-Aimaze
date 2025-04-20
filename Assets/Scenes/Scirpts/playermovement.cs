using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class playermovement : MonoBehaviour
{
    public bool inverted = false;
    public bool disabled = false;
    public bool orangeflag = false;
    public bool purpleflag = false;
    public bool blackflag = false;
    public bool cyanflag = false;
    public bool greenflag = false;

    private Rigidbody rb;
    public float moveSpeed; // Speed at which the object will move
    public float boostedSpeed; // Boosted speed when the button is pressed
    private float currentSpeed; // Current speed of the player
    private float boostDuration = 5.0f; // Duration of the boost
    private float boostCooldown = 10.0f; // Cooldown period between boosts
    private float boostTimer = 0.0f; // Timer to track boost duration
    private float cooldownTimer = 0.0f; // Timer to track cooldown period
    private GameObject greenCube;
    [SerializeField] private GameObject bluecube;

    private GameObject p2;
    private playermovement22 p2movement;

    public enum PowerUp
    {
        slowEnemy,
        fastEnemy,
        invertEnemy,
        disableEnemy
    }

    private void Start()
    {
        greenCube = GameObject.Find("greencube");
        if (greenCube == null)
        {
            Debug.LogError("Greencube not found!");
        }

        p2 = GameObject.Find("Capsule2");
        p2movement = p2.GetComponent<playermovement22>();

        moveSpeed = 15f;
        boostedSpeed = 30f;
        currentSpeed = moveSpeed; // Initialize currentSpeed with moveSpeed
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check for speed boost key press (slash key in this example)
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer <= 0 && !disabled)
        {
            currentSpeed = boostedSpeed; // Increase speed
            boostTimer = boostDuration; // Start boost timer
            cooldownTimer = boostCooldown; // Start cooldown timer
        }

        // Update boost timer
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
        }

        if (boostTimer <= 0)
        {
            currentSpeed = moveSpeed; // Reset speed to normal after boost duration
        }

        // Update cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Get the horizontal and vertical inputs
        float moveHorizontal = 0f;
        float moveVertical = 0f;
        if (gameObject.name == "Capsule") {
            if (Input.GetKey(KeyCode.A))
                moveHorizontal += 1f;
            if (Input.GetKey(KeyCode.D))
                moveHorizontal -= 1f;
            if (Input.GetKey(KeyCode.W))
                moveVertical -= 1f;
            if (Input.GetKey(KeyCode.S))
                moveVertical += 1f;
        }

        if (gameObject.name == "Capsule2") {
            if (Input.GetKey(KeyCode.LeftArrow))
                moveHorizontal += 1f;
            if (Input.GetKey(KeyCode.RightArrow))
                moveHorizontal -= 1f;
            if (Input.GetKey(KeyCode.UpArrow))
                moveVertical -= 1f;
            if (Input.GetKey(KeyCode.DownArrow))
                moveVertical += 1f;
        }

        if (inverted)
        {
            moveHorizontal *= -1;
            moveVertical *= -1;
        }

         // Create a movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the Rigidbody
        rb.velocity = movement * currentSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "powerup")
        {
            System.Random rnd = new System.Random();
            int rnd_num = rnd.Next(6);
            switch(rnd_num)
            {
                case 0:
                    // slow down enemy 3 sec
                    ApplyPowerUp(PowerUp.slowEnemy, 3f);
                    break;
                case 1:
                    // speed up enemy 3 sec
                    ApplyPowerUp(PowerUp.fastEnemy, 3f);
                    break;
                case 2:
                    // Add an additional red capsule to chase enemy
                    GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("enemy2");
                    List<GameObject> unactiveEnemies2 = new List<GameObject>();
                    foreach (GameObject enemy2 in enemies2)
                    {
                        if (!enemy2.GetComponent<MeshRenderer>().enabled)
                        {
                            unactiveEnemies2.Add(enemy2);
                        }
                    }
                    if (unactiveEnemies2.Count > 0)
                    {
                        int index = rnd.Next(unactiveEnemies2.Count);
                        GameObject chosenEnemy2 = unactiveEnemies2[index];
                        chosenEnemy2.GetComponent<MeshRenderer>().enabled = true;
                        chosenEnemy2.GetComponent<CapsuleCollider>().enabled = true;
                        chosenEnemy2.GetComponent<enemycontroller>().enabled = true;
                    }
                    break;
                case 3:
                    // teleports enemy to a random predetermined spot
                    GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("randomspots");
                    if (spawnPoints.Length > 0)
                    {
                        int index = rnd.Next(spawnPoints.Length); // Select a random index
                        GameObject chosenSpawnPoint = spawnPoints[index]; // Choose the spawn point
                        GameObject targetPlayer = GameObject.Find("Capsule2"); // Find the Capsule2 GameObject
                        if (targetPlayer != null)
                        {
                            targetPlayer.transform.position = chosenSpawnPoint.transform.position; // Move Capsule2 to the chosen location
                        }
                    }
                    break;
                case 4:
                    // invert enemy movement for 5 sec
                    ApplyPowerUp(PowerUp.invertEnemy, 5f);
                    break;
                case 5:
                    // disable enemy boost for 10 sec
                    ApplyPowerUp(PowerUp.disableEnemy, 10f);
                    break;
                default:
                    // do nothing
                    break;
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "orangecube")
        {
            orangeflag = true;
            GameObject[] orange = GameObject.FindGameObjectsWithTag("orange");
            if (orange.Length > 0) {
                foreach (GameObject x in orange){
                    Destroy(x);
                }
            }
        }

        if (other.gameObject.name == "purplecube")
        {
            purpleflag = true;
            GameObject[] purple = GameObject.FindGameObjectsWithTag("purple");
            if (purple.Length > 0 ){
                foreach (GameObject x in purple){
                    Destroy(x);
                }
            }
        }

        if (other.gameObject.name == "blackcube")
        {
            blackflag = true;
            GameObject[] black = GameObject.FindGameObjectsWithTag("black");
            if (black.Length > 0 ){
                foreach (GameObject x in black){
                    Destroy(x);
                }
            }
        }

        if (other.gameObject.name == "cyancube")
        {
            cyanflag = true;
            GameObject[] cyan = GameObject.FindGameObjectsWithTag("cyan");
            if (cyan.Length > 0 ){
                foreach (GameObject x in cyan){
                    Destroy(x);
                }
            }
        }
        
        // Check for greengate interaction based on flags
        if (other.gameObject.name == "greengate" && orangeflag && purpleflag && blackflag && cyanflag)
        {
            greenflag = true;
            Destroy(other.gameObject); // Destroy the greengate
        }
        else if(other.gameObject.name == "greengate" && !greenflag)
        {
            // Example teleportation logic
            Debug.Log("Teleporting... Before: " + transform.position);
            // Directly set the position without disabling/enabling NavMeshAgent
            transform.position = bluecube.transform.position;
            Debug.Log("Teleported to: " + transform.position);
        }
    }

    private void ApplyPowerUp(PowerUp power, float delay)
    {
        Debug.Log("Player 1 applies: " + power);

        // apply power up
        switch(power)
        {
            case PowerUp.slowEnemy:
                p2movement.moveSpeed /= 2;
                p2movement.boostedSpeed /= 2;
                break;
            case PowerUp.fastEnemy:
                p2movement.moveSpeed *= 5;
                p2movement.boostedSpeed *= 5;
                break;
            case PowerUp.invertEnemy:
                p2movement.inverted = true;
                break;
            case PowerUp.disableEnemy:
                p2movement.disabled = true;
                break;
            default:
                // do nothing
                break;
        }

        StartCoroutine(RevertPowerUp(power, delay));
    }

    private IEnumerator RevertPowerUp(PowerUp power, float delay)
    {
        yield return new WaitForSeconds(delay);

        // revert power up
        switch(power)
        {
            case PowerUp.slowEnemy:
                p2movement.moveSpeed *= 2;
                p2movement.boostedSpeed *= 2;
                break;
            case PowerUp.fastEnemy:
                p2movement.moveSpeed /= 5;
                p2movement.boostedSpeed /= 5;
                break;
            case PowerUp.invertEnemy:
                p2movement.inverted = false;
                break;
            case PowerUp.disableEnemy:
                p2movement.disabled = false;
                break;
            default:
                // do nothing
                break;
        }

        Debug.Log("Player 1 reverts: " + power);
    }
}
