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

    PauseMenu pm;

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
    public float pinkPlatformCount;
    public float fastPlatformCount;
    [HideInInspector]public GameObject rotatingPlatformCountText;
    [HideInInspector]public GameObject gravityPlatformCountText;
    [HideInInspector]public GameObject jumpPlatformCountText;
    [HideInInspector]public GameObject purplePlatformCountText;
    [HideInInspector]public GameObject pinkPlatformCountText;
    [HideInInspector]public GameObject fastPlatformCountText;


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
        pm = FindObjectOfType<PauseMenu>();

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
        pinkPlatformCountText = invCount.pinkPlatformText;
        fastPlatformCountText = invCount.fastPlatformText;
        rotatingPlatformCountText.GetComponent<Text>().text = rotatingPlatformCount.ToString();
        gravityPlatformCountText.GetComponent<Text>().text = gravityPlatformCount.ToString();
        jumpPlatformCountText.GetComponent<Text>().text = jumpPlatformCount.ToString();
        purplePlatformCountText.GetComponent<Text>().text = purplePlatformCount.ToString();
        pinkPlatformCountText.GetComponent<Text>().text = pinkPlatformCount.ToString();
        fastPlatformCountText.GetComponent<Text>().text = fastPlatformCount.ToString();


        //Setting the Get Key GameObject to the Goal Script
        goal = FindObjectOfType<Goal>();
        goal.getKeyText = invCount.getKeyText;
        goal.getKeyText.GetComponent<Text>().enabled = false;

        placeAllPlatformsText = invCount.placeAllPlatformsText;                                         //Setting the Text of placing all platforms.
        placeAllPlatformsText.SetActive(false);
        changeColorText = invCount.changeColorText;

        //Pause Menu settings
        pauseMenu = invCount.pauseMenu;
        pauseMenu.SetActive(false);


        if (levelNumber == 11 || levelNumber == 20)
        {
            StartCoroutine(ShowChangeColorText(1.6f));
        }

        if (levelNumber < 11)
        {
            gam.secOneAudioCounter = 500;
        }

        else if (levelNumber > 10 && levelNumber < 20)
        {
            gam.secTwoAudioCounter = 500;
        }

        else if (levelNumber > 19)
        {
            gam.secThreeAudioCounter = 500;
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

                if (levelNumber > 11 && levelNumber <= 20)
                {
                    playerScript.playerColor = 2;
                    player.GetComponent<SpriteRenderer>().color = playerScript.c2;
                }

                else if (levelNumber > 20)
                {
                    playerScript.playerColor = 3;
                    player.GetComponent<SpriteRenderer>().color = playerScript.c3;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }

        if(levelNumber == 11)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (!prepPhase)
                {
                    changeColorText.SetActive(false);
                }
            }
        }
    }

    public void EndPrepPhase()
    {
        prepPhase = false;
        inventory.SetActive(false);
        PrepPhaseEnded.Invoke();
        player.GetComponent<CharacterController2D>().enabled = true;


        invCount.deathCounter.GetComponent<Text>().color = invCount.c2;                                                                //Setting Death counter text to White
        invCount.levelNumberText.GetComponent<Image>().color = invCount.c2;                                                          //Setting Level Number text to White
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
        
        invCount.deathCounter.GetComponent<Text>().color = invCount.c1;                                                                //Setting Death counter text to Blue
        invCount.levelNumberText.GetComponent<Image>().color = invCount.c1;                                                          //Setting Level Number text to Blue
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
            gam.masterVolume = canvas.GetComponent<PauseMenu>().volumeSlider.GetComponent<Slider>().value;
        }

        else if (paused == false)
        {
            paused = true;
            canvas.GetComponent<PauseMenu>().volumeSlider.GetComponent<Slider>().value = gam.masterVolume;
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
