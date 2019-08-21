using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public Vector3 startingCoordinates;
    [SerializeField] GameObject player;

    public int levelNumber;

    [Tooltip("Type the name of the intended next level in this field. Do not forget to include that level into the Build Settings.")]
    public string nextLevel;

    public float platformIDNumber;

    //Preparation phase Variables
    public static UnityEvent PrepPhaseEnded = new UnityEvent();
    public static UnityEvent PrepPhaseStarted = new UnityEvent();
    public bool prepPhase;
    public bool hasKey;

    Goal goal;

    [Header("Canvas GameObjects")]
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject prepPhaseButton;
    [SerializeField] GameObject canvas;


    InventoryCountDefiner invCount;
    [Header("Inventory Counters")]
    public float rotatingPlatformCount;
    public float gravityPlatformCount;
    public float jumpPlatformCount;
    [HideInInspector]public GameObject rotatingPlatformCountText;
    [HideInInspector]public GameObject gravityPlatformCountText;
    [HideInInspector]public GameObject jumpPlatformCountText;


    [Header("Gravity Variables")]
    //Gravity Platform Variables
    public float negativeGravity;
    public float positiveGravity;
    [Range(-2,3)]
    public float currentLevelStartingGravity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
        startingCoordinates = player.transform.position;
        player.GetComponent<Rigidbody2D>().gravityScale = currentLevelStartingGravity;

        if (currentLevelStartingGravity < 0)
        {
            player.transform.eulerAngles = new Vector3(0, 180f, 180f);
        }
        else if (currentLevelStartingGravity > 0)
        {
            player.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        platformIDNumber = 0;
        canvas.SetActive(true);
        prepPhase = true;
        prepPhaseButton.SetActive(false);
        startButton.SetActive(true);

        //Inventory Count Texts Referencing and Printing their texts at start
        invCount = FindObjectOfType<InventoryCountDefiner>();
        rotatingPlatformCountText = invCount.rotatingText;
        gravityPlatformCountText = invCount.gravityText;
        jumpPlatformCountText = invCount.jumpPlatText;
        rotatingPlatformCountText.GetComponent<Text>().text = rotatingPlatformCount.ToString();
        gravityPlatformCountText.GetComponent<Text>().text = gravityPlatformCount.ToString();
        jumpPlatformCountText.GetComponent<Text>().text = jumpPlatformCount.ToString();


        //Setting the Get Key GameObject to the Goal Script
        goal = FindObjectOfType<Goal>();
        goal.getKeyText = invCount.getKeyText;
        goal.getKeyText.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if(prepPhase == true)
            {
                EndPrepPhase();
                print("prep ended");
            }

            if (prepPhase == false)
            {
                StartPrepPhase();
                print("prep started");
            }
        }
    }

    public void EndPrepPhase()
    {
        prepPhase = false;
        inventory.SetActive(false);
        startButton.SetActive(false);
        prepPhaseButton.SetActive(true);
        PrepPhaseEnded.Invoke();
    }

    public void StartPrepPhase()
    {
        prepPhase = true;
        inventory.SetActive(true);
        startButton.SetActive(true);
        prepPhaseButton.SetActive(false);
        PrepPhaseStarted.Invoke();


        //Sending player back to the start of the level
        player.transform.position = startingCoordinates;
        player.GetComponent<Rigidbody2D>().gravityScale = currentLevelStartingGravity;
        if (currentLevelStartingGravity > 0)
        {
            player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (currentLevelStartingGravity < 0)
        {
            player.transform.eulerAngles = new Vector3(0, 180f, 180f);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
