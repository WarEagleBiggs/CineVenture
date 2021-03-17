using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player move vars
    public Rigidbody2D theRB;
    public float moveSpeed;

    //Bools
    public bool isShrubInInventory = false;

    // Objs
    public GameObject Shrub;
    public GameObject Dial1;
    public GameObject Dial2;
    public GameObject Dial3;
    public GameObject Dial4;
    public GameObject Dial5;

    //Player anim vars
    public Animator myAnim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shrub")
        {
            Debug.Log("Shrub acquired");
            isShrubInInventory = true;
            Shrub.SetActive(false);
        } else if (collision.gameObject.tag == "DialogueTrigger1")
        {
            if (isShrubInInventory)
            {
                Dial5.SetActive(true);
            } else
            {
                Dial1.SetActive(true);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Dial1.activeSelf)
            {
                Dial1.SetActive(false);
                Dial2.SetActive(true);
            } else if (Dial2.activeSelf)
            {
                Dial2.SetActive(false);
                Dial3.SetActive(true);
            } else if (Dial3.activeSelf)
            {
                Dial3.SetActive(false);
                Dial4.SetActive(true);
            } else if (Dial4.activeSelf)
            {
                Dial4.SetActive(false);
            }
        }

       

        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        myAnim.SetFloat("MoveX", theRB.velocity.x);
        myAnim.SetFloat("MoveY", theRB.velocity.y);
        
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        { 
            myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }

    }

}
