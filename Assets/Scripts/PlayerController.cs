using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Other script
    public GameController Gcontrol;

    // Player move vars
    public Rigidbody2D theRB;
    public float moveSpeed;

    //ArrowLogic
    public Rigidbody2D ArrowRB;
    public float ArrowBoostSpeed = 1f;

    //Car rigidbody
    public Rigidbody2D CarRB;

    //Bools
    public bool isShrubInInventory = false;
    public bool isConversation1Done = false;
    public bool isLevel1Active = false;
    public bool isLevel2Active = false;
    public bool isLevel3Active = false;
    public bool hasOnlyHappenedOnce2 = false;
    public bool playerHasEnteredCar = false;
    public bool isArrowInGreen = false;

    //floats
    public float CanOnlyHappenOnce1 = 0f;
    public float CanOnlyHappenOnce2 = 0f;
    public float CanOnlyHappenOnce3 = 0f;
    public float CarMoveSpeed;



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
    public GameObject MatrixIntro;
    public GameObject MiniMap;
    public GameObject arrow;
    public GameObject Bar;
    public GameObject CarStill;
    public GameObject MovingCar;
    public GameObject PlayerCam;
    public GameObject ColliderSet2;
    public GameObject BTFdial;
    public GameObject CarEffect;
    public List<GameObject> ObjsToDisable;
    public GameObject Intro3;
    public GameObject EndScreen;
    



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
        //NO
    }

    IEnumerator waiter()
    {
        
        //Wait for 8 seconds
        yield return new WaitForSeconds(12);
        Intro1.SetActive(false);

    }

    IEnumerator waiter2()
    {
        //Wait for 8 seconds
        yield return new WaitForSeconds(5);
        MatrixIntro.SetActive(false);
    }

    IEnumerator waiter3()
    {
        yield return new WaitForSeconds(5);
        Intro3.SetActive(false);
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
        } else if (collision.gameObject.tag == "Deathray") { 

            Dead2(); 
        } 
        else if(collision.gameObject.tag == "Gate2") { 
            Gcontrol.Level2.SetActive(false);
            Gcontrol.Level3.SetActive(true);

        } else if(collision.gameObject.tag == "Car") 
        {
            
            //SpriteRenderer test = Player.GetComponent<SpriteRenderer>();
            PlayerCam.SetActive(false);
            Player.transform.position = new Vector3(1000f, 10000f, 1f);
            CarStill.SetActive(false);
            Bar.SetActive(true);
            arrow.SetActive(true);
            MovingCar.SetActive(true);
            playerHasEnteredCar = true;
            ColliderSet2.SetActive(false);
            MoveCar();
        }
    }

    void Intro1Active()
    {
        CanOnlyHappenOnce1++;
        if(CanOnlyHappenOnce1 == 1f)
        {
            Intro1.SetActive(true);
        }
        
    }

    public void MoveCar()
    {

        //CarRB.AddForce(transform.right * CarMoveSpeed);
        CarRB.velocity = transform.right * CarMoveSpeed;
    }

    void Intro2Active()
    {

        CanOnlyHappenOnce2++;
        if (CanOnlyHappenOnce2 == 1f)
        {
            MatrixIntro.SetActive(true);
        }

    }

    void Intro3Active()
    {
        CanOnlyHappenOnce3++;
            if(CanOnlyHappenOnce3 == 1f)
        {
            Intro3.SetActive(true);
        }
    }

    

    private bool PrevIsGreen;
    private float StartTimeWithinGreenSec;
    public List<GameObject> SequenceImages;
    public bool IsRaceCompleted = false;
    

    void MonitorCount()
    {
        if (isArrowInGreen)
        {

            

            if (PrevIsGreen != isArrowInGreen)
            {
                StartTimeWithinGreenSec = Time.time;
            }
            // set visibility on images
            float durationSec = Time.time - StartTimeWithinGreenSec;

            int index = (int)durationSec;

            if (index >= 10)
            {
                IsRaceCompleted = true;
                //MovingCar.SetActive(false);
                MovingCar.GetComponent<SpriteRenderer>().enabled = false;
                CarEffect.SetActive(true);
                foreach(GameObject obj in ObjsToDisable)
                {
                    obj.SetActive(false);
                }
            }

            int i = 0;
            foreach(GameObject obj in SequenceImages)
            {
                if (i <= index)
                {
                    obj.SetActive(true);
                }
                else
                {
                    obj.SetActive(false);
                }

                i++;
            }
        } else
        {
            // hide all images
            foreach(GameObject obj in SequenceImages)
            {
                obj.SetActive(false);
            }
        }
        // sets prev to current
        PrevIsGreen = isArrowInGreen;
    }

    public bool shouldOnlyHappenOnce = false;
    public bool isRoutineRunning = false;

    IEnumerator End()
    {
        yield return new WaitForSeconds(2);
        EndScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        EndScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        


    }


    // Update is called once per frame
    void Update()
    {

        if (IsRaceCompleted)
        {
            CarRB.velocity = transform.right * 0f;
            StartCoroutine(End());
        }


        MonitorCount();

    /* if (isArrowInGreen)
        {
            StartCoroutine(tenseconds());
        } 
     if (!isArrowInGreen)
        {
            StopCoroutine(tenseconds());
        }*/

        if (Gcontrol.Level1.activeSelf)
        {
            isLevel1Active = true;
        } else if (Gcontrol.Level2.activeSelf)
        {
            isLevel2Active = true;
        } else if (Gcontrol.Level3.activeSelf)
        {
            isLevel3Active = true;
        }


        // moves arrow
        Vector3 arrowPos = arrow.transform.position;
        arrowPos.x = Bar.transform.position.x;
        arrow.transform.position = arrowPos;

        // moves car flames
        Vector3 FirePos = CarEffect.transform.position;
        FirePos.x = MovingCar.transform.position.x;
        CarEffect.transform.position = FirePos;


        if (MatrixIntro.activeSelf)
        {
            MiniMap.SetActive(false);
        } else
        {
            MiniMap.SetActive(true);
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
            Intro2Active();
            StartCoroutine(waiter2());
        } else if (isLevel3Active) {
            Intro3Active();
            StartCoroutine(waiter3());
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
            } else if (isLevel3Active && playerHasEnteredCar)
            {
                ArrowRB.AddForce(transform.up * ArrowBoostSpeed);
                //Debug.Log("Works");
            } else if (BTFdial.activeSelf)
            {
                BTFdial.SetActive(false);
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
