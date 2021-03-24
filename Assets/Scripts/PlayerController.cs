using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Other script
    public GameController Gcontrol;

    // Player move vars
    public Rigidbody2D theRB;
    public float moveSpeed;

    //Bools
    public bool isShrubInInventory = false;
    public bool isConversation1Done = false;
    public bool isLevel1Active = false;
    public bool isLevel2Active = false;
    public bool isLevel3Active = false;
    public bool hasOnlyHappenedOnce2 = false;

    //floats
    public float CanOnlyHappenOnce1 = 0f;

    // Objs
    public GameObject Player;
    public GameObject Shrub;
    public GameObject Dial1;
    public GameObject Dial2;
    public GameObject Dial3;
    public GameObject Dial4;
    public GameObject Dial5;
    public GameObject MatrixDial1;
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    public GameObject Knights;
    public GameObject RocksBlockingPath;
    public GameObject Intro1;
    public GameObject LineOfSight1;
    public GameObject LineOfSight2;
    public GameObject LineOfSight3;
    public GameObject LineOfSight4;
    public GameObject LineOfSight5;
    public GameObject RetryScreen;



    //Trigger objs
    public GameObject Trigger1;
    public GameObject Trigger2;
    public GameObject Trigger3;

    //Player anim vars
    public Animator myAnim;


    void Start()
    {
        //remember this happens in INTRO level!
        //nothing yet
    }

    IEnumerator waiter()
    {
        
        //Wait for 8 seconds
        yield return new WaitForSeconds(12);
        Intro1.SetActive(false);

    }

    IEnumerator Eyesight()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            LineOfSight1.transform.Rotate(new Vector3(0, 0, -15));
            LineOfSight2.transform.Rotate(new Vector3(0, 0, -15));
            LineOfSight3.transform.Rotate(new Vector3(0, 0, -15));
            LineOfSight4.transform.Rotate(new Vector3(0, 0, -15));
            LineOfSight5.transform.Rotate(new Vector3(0, 0, -15));
            yield return new WaitForSeconds(0.5f);
            LineOfSight1.transform.Rotate(new Vector3(0, 0, -25));
            LineOfSight2.transform.Rotate(new Vector3(0, 0, -25));
            LineOfSight3.transform.Rotate(new Vector3(0, 0, -25));
            LineOfSight4.transform.Rotate(new Vector3(0, 0, -25));
            LineOfSight5.transform.Rotate(new Vector3(0, 0, -25));
            yield return new WaitForSeconds(0.5f);
            LineOfSight1.transform.Rotate(new Vector3(0, 0, -35));
            LineOfSight2.transform.Rotate(new Vector3(0, 0, -35));
            LineOfSight3.transform.Rotate(new Vector3(0, 0, -35));
            LineOfSight4.transform.Rotate(new Vector3(0, 0, -35));
            LineOfSight5.transform.Rotate(new Vector3(0, 0, -35));
            yield return new WaitForSeconds(1f);
            LineOfSight1.transform.Rotate(new Vector3(0, 0, 35));
            LineOfSight2.transform.Rotate(new Vector3(0, 0, 35));
            LineOfSight3.transform.Rotate(new Vector3(0, 0, 35));
            LineOfSight4.transform.Rotate(new Vector3(0, 0, 35));
            LineOfSight5.transform.Rotate(new Vector3(0, 0, 35));
            yield return new WaitForSeconds(0.5f);
            LineOfSight1.transform.Rotate(new Vector3(0, 0, 25));
            LineOfSight2.transform.Rotate(new Vector3(0, 0, 25));
            LineOfSight3.transform.Rotate(new Vector3(0, 0, 25));
            LineOfSight4.transform.Rotate(new Vector3(0, 0, 25));
            LineOfSight5.transform.Rotate(new Vector3(0, 0, 25));
            yield return new WaitForSeconds(0.5f);
            LineOfSight1.transform.Rotate(new Vector3(0, 0, 15));
            LineOfSight2.transform.Rotate(new Vector3(0, 0, 15));
            LineOfSight3.transform.Rotate(new Vector3(0, 0, 15));
            LineOfSight4.transform.Rotate(new Vector3(0, 0, 15));
            LineOfSight5.transform.Rotate(new Vector3(0, 0, 15));
            //Debug.Log("yay");
        }
    }

    IEnumerator Retry()
    {
        RetryScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        RetryScreen.SetActive(false);
    }


    void Dead2()
    {
        StartCoroutine(Retry());
        Player.transform.localPosition = new Vector3(0.6f, -1.75f, 0f);
    }



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
        } else if (collision.gameObject.tag == "Gate1")
        {

            Gcontrol.Level1.SetActive(false);
            Gcontrol.Level2.SetActive(true);
        } else if (collision.gameObject.tag == "Deathray") { Dead2(); } 
    }

    void Intro1Active()
    {
        CanOnlyHappenOnce1++;
        if(CanOnlyHappenOnce1 == 1f)
        {
            Intro1.SetActive(true);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Gcontrol.Level1.activeSelf)
        {
            isLevel1Active = true;
        } else if (Gcontrol.Level2.activeSelf)
        {
            isLevel2Active = true;
        }


        if (isLevel1Active)
        {
            Intro1Active();
            StartCoroutine(waiter());

        } else if (isLevel2Active && hasOnlyHappenedOnce2 == false)
        {
            //Debug.Log("Checking");
            hasOnlyHappenedOnce2 = true;
            StartCoroutine(Eyesight());
        }


        if (isShrubInInventory)
        {
            Obj2.SetActive(false);
            Obj3.SetActive(true);
        }

        if (isConversation1Done)
        {
            Knights.transform.localPosition = new Vector3(-5.7f, 0f, 0f);
            Obj3.SetActive(false);
            Obj4.SetActive(true);
        }

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
                Obj1.SetActive(false);
                Obj2.SetActive(true);
                RocksBlockingPath.SetActive(false);
            } else if (Dial5.activeSelf)
            {
                Dial5.SetActive(false);
                
                Trigger1.SetActive(false);
                Trigger2.SetActive(false);
                Trigger3.SetActive(false);
                isConversation1Done = true;
            } else if (MatrixDial1.activeSelf)
            {
                MatrixDial1.SetActive(false);
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
