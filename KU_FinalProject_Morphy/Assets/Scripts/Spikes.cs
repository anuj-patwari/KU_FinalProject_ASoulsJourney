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
            col.gameObject.transform.position = gm.startingCoordinates;
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = gm.currentLevelStartingGravity;
            col.gameObject.GetComponent<Player>().runSpeed = 20f;
            if (gm.currentLevelStartingGravity > 0)
            {
                col.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (gm.currentLevelStartingGravity < 0)
            {
                col.gameObject.transform.eulerAngles = new Vector3(0, 180f, 180f);
            }
            col.gameObject.GetComponent<Player>().Die();
        }
    }
}
