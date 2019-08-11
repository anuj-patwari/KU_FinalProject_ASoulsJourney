using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if(col.gameObject.GetComponent<Rigidbody2D>().gravityScale == gm.positiveGravity)
            {
                col.gameObject.GetComponent<Rigidbody2D>().gravityScale = gm.negativeGravity;
                col.gameObject.transform.eulerAngles = new Vector3(0, 180f, 180f);
            }

            else if (col.gameObject.GetComponent<Rigidbody2D>().gravityScale == gm.negativeGravity)
            {
                col.gameObject.GetComponent<Rigidbody2D>().gravityScale = gm.positiveGravity;
                col.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
