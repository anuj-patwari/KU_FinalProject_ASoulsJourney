using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            // Get reference to the player
            Player player = col.gameObject.GetComponent<Player>();

            // Detach and play death particles at the point of death
            GameObject deathParticles = player.deathParticles;
            deathParticles.transform.position = col.gameObject.transform.position; // Set to player's current position
            deathParticles.transform.parent = null; // Detach from player
            deathParticles.SetActive(true); // Activate the particles

            // Reset player position to respawn point
            col.gameObject.transform.position = gm.startingCoordinates;

            // Reset gravity and other player properties
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = gm.currentLevelStartingGravity;
            col.gameObject.GetComponent<Player>().runSpeed = 20f;

            // Adjust player rotation based on gravity
            if (gm.currentLevelStartingGravity > 0)
            {
                col.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (gm.currentLevelStartingGravity < 0)
            {
                col.gameObject.transform.eulerAngles = new Vector3(0, 180f, 180f);
            }

            // Call player's Die method
            col.gameObject.GetComponent<Player>().Die();
        }
    }
}
