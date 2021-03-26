using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public PlayerController PlayerControlScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopSpeed")
        {
            PlayerControlScript.CarMoveSpeed = 30f;
            PlayerControlScript.MoveCar();
            Debug.Log(PlayerControlScript.CarMoveSpeed);
        } else if (collision.gameObject.tag == "GoodSpeed")
        {
            PlayerControlScript.CarMoveSpeed = 20f;
            PlayerControlScript.MoveCar();
            Debug.Log(PlayerControlScript.CarMoveSpeed);
        } else if (collision.gameObject.tag == "SlowSpeed")
        {
            PlayerControlScript.CarMoveSpeed = 10f;
            PlayerControlScript.MoveCar();
            Debug.Log(PlayerControlScript.CarMoveSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
