using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredPlatforms : MonoBehaviour
{
    Player player;

    [Tooltip("1 for White, 2 for Purple, 3 for Red")]
    public float platformColor;



    [SerializeField] GameObject cross;
    public bool placed;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        if(platformColor == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = player.c1;
        }

        else if (platformColor == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = player.c2;
        }
        else if (platformColor == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().color = player.c3;
        }

        if (placed == true)
        {
            cross.SetActive(true);
        }

        else if (placed == false)
        {
            cross.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerColor == platformColor)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}