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
    GlobalAudioManager gam;
    Player playerScript;

    [Header("Canvas GameObjects")]
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject placeAllPlatformsText;                                          //Place all platforms Text.
    [SerializeField] GameObject changeColorText;

    public bool paused;                                                                         //Checking if the game is Paused.

    InventoryCountDefiner invCount;
    [Header("Inventory Counters")]
    public float rotatingPlatformCount;
    public float gravityPlatformCount;
    public float jumpPlatformCount;
    public float purplePlatformCount;
    [HideInInspector]public GameObject rotatingPlatformCountText;
    [HideInInspector]public GameObject gravityPlatformCountText;
    [HideInInspector]public GameObject jumpPlatformCountText;
    [HideInInspector]public GameObject purplePlatformCountText;


    [Header("Gravity Variables")]
    //Gravity Platform Variables
    public float negativeGravity;
    public float positiveGravity;
    [Range(-2,3)]
    public float currentLevelStartingGravity = 3f;

    // Start is called before the first frame update
    void Start()
    {

        gam = FindObjectOfType<GlobalAudioManager>();
        playerScript = FindObjectOfType<Player>();

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


        //Inventory Count Texts Referencing and Printing their texts at start
        invCount = FindObjectOfType<InventoryCountDefiner>();
        rotatingPlatformCountText = invCount.rotatingText;
        gravityPlatformCountText = invCount.gravityText;
        jumpPlatformCountText = invCount.jumpPlatText;
        purplePlatformCountText = invCount.purplePlatText;
        rotatingPlatformCountText.GetComponent<Text>().text = rotatingPlatformCount.ToString();
        gravityPlatformCountText.GetComponent<Text>().text = gravityPlatformCount.ToString();
        jumpPlatformCountText.GetComponent<Text>().text = jumpPlatformCount.ToString();
        purplePlatformCountText.GetComponent<Text>().text = purplePlatformCount.ToString();


        //Setting the Get Key GameObject to the Goal Script
        goal = FindObjectOfType<Goal>();
        goal.getKeyText = invCount.getKeyText;
        goal.getKeyText.GetComponent<Image>().enabled = false;

        placeAllPlatformsText = invCount.placeAllPlatformsText;                                         //Setting the Text of placing all platforms.
        placeAllPlatformsText.SetActive(false);
        changeColorText = invCount.changeColorText;

        //Pause Menu settings
        pauseMenu = invCount.pauseMenu;
        pauseMenu.SetActive(false);


        if (levelNumber == 10)
        {
            StartCoroutine(ShowChangeColorText(1.6f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if(prepPhase == true)
            {
                if (GameObject.FindObjectOfType<ClickablePlatformDefiner>() == null)
                {
                    EndPrepPhase();
                }
                
                else if (GameObject.FindObjectOfType<ClickablePlatformDefiner>() != null)
                {
                    placeAllPlatformsText.SetActive(true);
                    StartCoroutine(AllPlatformsNotPlaced(3f));
                }
            }

            else
            {
                StartPrepPhase();

                if (levelNumber > 9 && levelNumber <= 18)
                {
                    if (playerScript.playerColor == 1)
                    {
                        playerScript.playerColor = 2;
                        player.GetComponent<SpriteRenderer>().color = playerScript.c2;
                    }
                    else if (playerScript.playerColor == 2)
                    {
                        playerScript.playerColor = 1;
                        player.GetComponent<SpriteRenderer>().color = playerScript.c1;
                    }
                }

                else if (levelNumber > 18)
                {
                    if (playerScript.playerColor == 1)
                    {
                        playerScript.playerColor = 2;
                        player.GetComponent<SpriteRenderer>().color = playerScript.c2;
                    }
                    else if (playerScript.playerColor == 2)
                    {
                        playerScript.playerColor = 3;
                        player.GetComponent<SpriteRenderer>().color = playerScript.c3;
                    }
                    else if (playerScript.playerColor == 3)
                    {
                        playerScript.playerColor = 1;
                        player.GetComponent<SpriteRenderer>().color = playerScript.c1;
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }

        if(levelNumber == 10)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                changeColorText.SetActive(false);
            }
        }
    }

    public void EndPrepPhase()
    {
        prepPhase = false;
        inventory.SetActive(false);
        PrepPhaseEnded.Invoke();
        player.GetComponent<CharacterController2D>().enabled = true;
    }

    public void StartPrepPhase()
    {
        prepPhase = true;
        inventory.SetActive(true);
        PrepPhaseStarted.Invoke();
        player.GetComponent<CharacterController2D>().enabled = false;

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

    void PauseGame()
    {
        if (paused == true)
        {
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gam.SaveVolume();
        }

        else if (paused == false)
        {
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator AllPlatformsNotPlaced(float delay)
    {
        yield return new WaitForSeconds(delay);
        placeAllPlatformsText.SetActive(false);
    }

    IEnumerator ShowChangeColorText(float delay)
    {
        yield return new WaitForSeconds(delay);
        changeColorText.SetActive(true);
    }
}
