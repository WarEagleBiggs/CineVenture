using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject IntroLevel;
    public GameObject TutorialLevel;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
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
        }

    }
}
