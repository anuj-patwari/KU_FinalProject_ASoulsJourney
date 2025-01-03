using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{

    //[SerializeField] GameObject leftButton;
    //[SerializeField] GameObject rightButton;
    [SerializeField] GameObject creditsText;
    //[SerializeField] GameObject specialThanksText;

    //private int menuNumber;

    // Start is called before the first frame update
    void Start()
    {
        creditsText.SetActive(true);
        //menuNumber = 1;
        //specialThanksText.SetActive(false);
        //leftButton.SetActive(false);
        //rightButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void SwitchButtonClicked()
    {
        if (menuNumber == 1)
        {
            creditsText.SetActive(false);
            specialThanksText.SetActive(true);
            leftButton.SetActive(true);
            rightButton.SetActive(false);
            menuNumber = 2;
        }

        else if (menuNumber == 2)
        {
            leftButton.SetActive(false);
            creditsText.SetActive(true);
            //specialThanksText.SetActive(false);
            rightButton.SetActive(true);
            menuNumber = 1;
        }
    }*/

    public void FollowMeOnlineButtonClicked()
    {
        Application.OpenURL("https://www.anujpatwari.com/links");
        print("All hail Social Media!");
    }

    public void GrumpyBilliButtonClicked()
    {
        Application.OpenURL("https://www.youtube.com/@GrumpyBilliGaming");
        print("Billi bhaiya!!");
    }

    public void OneUpGameDevButtonClicked()
    {
        Application.OpenURL("https://www.youtube.com/@OneUpGameDev");
        print("OneUp boiii!!");
    }

    public void WebsiteButtonClicked()
    {
        Application.OpenURL("https://www.anujpatwari.com");
        print("Website opened!");
    }
}
