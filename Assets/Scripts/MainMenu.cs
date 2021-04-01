using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> ThingsToDisable;
    public GameObject Loading;

    IEnumerator loading()
    {
        Loading.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void PlayGame()
    {
        
        

        foreach (GameObject obj in ThingsToDisable)
        {
            obj.SetActive(false);
        }
        StartCoroutine(loading());
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
