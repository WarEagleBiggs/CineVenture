using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject IntroLevel;
    public GameObject TutorialLevel;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Verify1;
    public GameObject Verify2;
    public GameObject Veryify3;

    public void playGame()
    {
        
        SceneManager.LoadScene("Game");
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            IntroLevel.SetActive(true);
            TutorialLevel.SetActive(false);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.U))
        {
            IntroLevel.SetActive(false);
            TutorialLevel.SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            IntroLevel.SetActive(false);
            TutorialLevel.SetActive(false);
            Level1.SetActive(true);
            Level2.SetActive(false);
            Level3.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.O))
        {
            IntroLevel.SetActive(false);
            TutorialLevel.SetActive(false);
            Level1.SetActive(false);
            Level2.SetActive(true);
            Level3.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.P))
        {
            IntroLevel.SetActive(false);
            TutorialLevel.SetActive(false);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Verify1.SetActive(true);
            Verify2.SetActive(true);
            Veryify3.SetActive(true);
        }

    }

    public void Yes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void no()
    {
        Verify1.SetActive(false);
        Verify2.SetActive(false);
        Veryify3.SetActive(false);
    }
}
