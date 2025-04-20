using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class playermovement22 : MonoBehaviour
{
    public bool inverted = false;
    public bool disabled = false;
    public bool orangeflag2 = false;
    public bool purpleflag2 = false;
    public bool blackflag2 = false;
    public bool cyanflag2 = false;
    public bool greenflag2 = false;

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

    private GameObject p1;
    private playermovement p1movement;

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

        rb = gameObject.GetComponent<Rigidbody>();
        p1 = GameObject.Find("Capsule");
        p1movement = p1.GetComponent<playermovement>();

        moveSpeed = 15f;
        boostedSpeed = 30f;
        currentSpeed = moveSpeed; // Initialize currentSpeed with moveSpeed
    }

    private void Update()
    {
        // Check for speed boost key press (slash key in this example)
        if (Input.GetKeyDown(KeyCode.Slash) && cooldownTimer <= 0 && !disabled)
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
            switch (rnd_num)
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
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
                    List<GameObject> unactiveEnemies = new List<GameObject>();
                    foreach (GameObject enemy in enemies)
                    {
                        if (!enemy.GetComponent<MeshRenderer>().enabled)
                        {
                            unactiveEnemies.Add(enemy);
                        }
                    }
                    if (unactiveEnemies.Count > 0)
                    {
                        int index = rnd.Next(unactiveEnemies.Count);
                        GameObject chosenEnemy = unactiveEnemies[index];
                        chosenEnemy.GetComponent<MeshRenderer>().enabled = true;
                        chosenEnemy.GetComponent<CapsuleCollider>().enabled = true;
                        chosenEnemy.GetComponent<enemycontroller>().enabled = true;
                    }
                    break;
                case 3:
                      GameObject[] spawnPoints2 = GameObject.FindGameObjectsWithTag("randomspots2");
                    if (spawnPoints2.Length > 0)
                    {
                        int index = rnd.Next(spawnPoints2.Length); // Select a random index
                        GameObject chosenSpawnPoint2 = spawnPoints2[index]; // Choose the spawn point
                        GameObject targetPlayer2 = GameObject.Find("Capsule"); // Find the Capsule2 GameObject
                        if (targetPlayer2 != null)
                        {
                            targetPlayer2.transform.position = chosenSpawnPoint2.transform.position; // Move Capsule2 to the chosen location
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
            orangeflag2 = true;
            GameObject[] orange2 = GameObject.FindGameObjectsWithTag("orange2");
            if (orange2.Length > 0 ){
                foreach (GameObject x in orange2){
                    Destroy(x);
                }
            }
        }

        if (other.gameObject.name == "purplecube")
        {
            purpleflag2 = true;
            GameObject[] purple2 = GameObject.FindGameObjectsWithTag("purple2");
            if (purple2.Length > 0 ){
                foreach (GameObject x in purple2){
                    Destroy(x);
                }
            }
        }

        if (other.gameObject.name == "blackcube")
        {
            blackflag2 = true;
            GameObject[] black2 = GameObject.FindGameObjectsWithTag("black2");
            if (black2.Length > 0 ){
                foreach (GameObject x in black2){
                    Destroy(x);
                }
            }
        }

        if (other.gameObject.name == "cyancube")
        {
            cyanflag2 = true;
            GameObject[] cyan2 = GameObject.FindGameObjectsWithTag("cyan2");
            if (cyan2.Length > 0 ){
                foreach (GameObject x in cyan2){
                    Destroy(x);
                }
            }
        }
        
        // Check for greengate interaction based on flags
        if (other.gameObject.name == "greengate" && orangeflag2 && purpleflag2 && blackflag2 && cyanflag2)
        {
            greenflag2 = true;
            Destroy(other.gameObject); // Destroy the greengate
        }
        else if(other.gameObject.name == "greengate" && !greenflag2)
        {
            // Example teleportation logic
            Debug.Log("Teleporting... Before: " + transform.position);
            // Directly set the position without disabling/enabling NavMeshAgent
            transform.position = bluecube.transform.position; // Assuming greenCube is your destination
            Debug.Log("Teleported to: " + transform.position);
        }
    }

    private void ApplyPowerUp(PowerUp power, float delay)
    {
        Debug.Log("Player 2 applies: " + power);

        // apply power up
        switch(power)
        {
            case PowerUp.slowEnemy:
                p1movement.moveSpeed /= 2;
                p1movement.boostedSpeed /= 2;
                break;
            case PowerUp.fastEnemy:
                p1movement.moveSpeed *= 5;
                p1movement.boostedSpeed *= 5;
                break;
            case PowerUp.invertEnemy:
                p1movement.inverted = true;
                break;
            case PowerUp.disableEnemy:
                p1movement.disabled = true;
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
                p1movement.moveSpeed = 15;
                p1movement.boostedSpeed = 30;
                break;
            case PowerUp.fastEnemy:
                p1movement.moveSpeed /= 5;
                p1movement.boostedSpeed /= 5;
                break;
            case PowerUp.invertEnemy:
                p1movement.inverted = false;
                break;
            case PowerUp.disableEnemy:
                p1movement.disabled = false;
                break;
            default:
                // do nothing
                break;
        }

        Debug.Log("Player 2 reverts: " + power);
    }
}
