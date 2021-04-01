using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public PlayerController PlayerControlScript;
    public bool hasonlyhappenedonce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "TopSpeed")
        {
            hasonlyhappenedonce = false;
            PlayerControlScript.CarMoveSpeed = 30f;
            PlayerControlScript.MoveCar();
            //Debug.Log(PlayerControlScript.CarMoveSpeed);
            //StopCoroutine(PlayerControlScript.tenseconds());
            PlayerControlScript.isRoutineRunning = false;
            PlayerControlScript.isArrowInGreen = false;
            /* PlayerControlScript.ONE.SetActive(false);
             PlayerControlScript.TWO.SetActive(false);
             PlayerControlScript.THREE.SetActive(false);
             PlayerControlScript.FOUR.SetActive(false);
             PlayerControlScript.FIVE.SetActive(false);
             PlayerControlScript.SIX.SetActive(false);
             PlayerControlScript.SEVEN.SetActive(false);
             PlayerControlScript.EIGHT.SetActive(false);
             PlayerControlScript.NINE.SetActive(false);
             PlayerControlScript.TEN.SetActive(false);*/
        } else if (collision.gameObject.tag == "GoodSpeed")
        {
            if (hasonlyhappenedonce == false)
            {
                PlayerControlScript.isRoutineRunning = true;
                hasonlyhappenedonce = true;
                PlayerControlScript.isArrowInGreen = true;
                PlayerControlScript.CarMoveSpeed = 20f;
                PlayerControlScript.MoveCar();
                //Debug.Log(PlayerControlScript.CarMoveSpeed);
               // StartCoroutine(PlayerControlScript.tenseconds());
            }
        } else if (collision.gameObject.tag == "SlowSpeed")
        {
            hasonlyhappenedonce = false;
            PlayerControlScript.CarMoveSpeed = 10f;
            PlayerControlScript.MoveCar();
            //Debug.Log(PlayerControlScript.CarMoveSpeed);
            PlayerControlScript.isRoutineRunning = false;
            PlayerControlScript.isArrowInGreen = false;
            //StopCoroutine(PlayerControlScript.tenseconds());
            /* PlayerControlScript.ONE.SetActive(false);
             PlayerControlScript.TWO.SetActive(false);
             PlayerControlScript.THREE.SetActive(false);
             PlayerControlScript.FOUR.SetActive(false);
             PlayerControlScript.FIVE.SetActive(false);
             PlayerControlScript.SIX.SetActive(false);
             PlayerControlScript.SEVEN.SetActive(false);
             PlayerControlScript.EIGHT.SetActive(false);
             PlayerControlScript.NINE.SetActive(false);
             PlayerControlScript.TEN.SetActive(false);*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
