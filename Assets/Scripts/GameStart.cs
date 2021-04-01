using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameController Gcontrol;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        Gcontrol.Level1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
