using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    [SerializeField] public TMP_Text textGameEnding;
    [SerializeField] private float walkSpeed = 8.0f;
    [SerializeField] private float turnSpeed = 10.0f;

    [SerializeField] public battery battery;
    [SerializeField] public textBatteriesLeft txtBatteriesLeft;
    [SerializeField] public textTimer timer;

    public Animator playerAnimation;
    public CharacterController characterController;

    public int numBatteries = 9;

    public bool faint;

    public bool wakeup;

    public bool d;

    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        
        characterController = GetComponent<CharacterController>();

        faint = false;

        wakeup = false;

        numBatteries = 9;

        door = GameObject.FindGameObjectWithTag("door");

        door.SetActive(false);

        textGameEnding.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
       if (timer.time > 0f)
        {
            if (numBatteries >= 1)
            {

                if (faint == false)
                {

                    float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
                    float vertical = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;

                    Vector3 movement = new Vector3(horizontal, 0, vertical);
                    movement = transform.TransformDirection(movement);
                    characterController.Move(movement);

                    bool horizontalAxisEntry = !Mathf.Approximately(horizontal, 0f);
                    bool verticalAxisEntry = !Mathf.Approximately(vertical, 0f);

                    if (horizontalAxisEntry || verticalAxisEntry)
                    {
                        playerAnimation.SetBool("move", true);

                    }
                    else
                    {
                        playerAnimation.SetBool("move", false);
                    }

                    Vector3 downward = Vector3.down * 9.81f * Time.deltaTime;
                    characterController.Move(downward);

                    transform.Rotate(Vector3.up, horizontal * turnSpeed);

                }


                if (faint == true)
                {

                    Invoke("wakeUp", 3.7f);

                    playerAnimation.SetBool("move", false);
                    playerAnimation.SetBool("faint", true);
                    


                }

                if (d == true)
                {
                    numBatteries = numBatteries - 1;

                    d = false;
                   
                }

            }
            
        }
       else
        {
            transform.position = new Vector3(-2.5f, 0f, 17.32f);
            transform.rotation = new Quaternion(0f, 180f, 0, 0);
            
        }

        if (numBatteries == 0)
        {
            
            playerAnimation.SetBool("move", false);
            

            GameObject[] drone = GameObject.FindGameObjectsWithTag("drone");

            for (int i = 0; i < drone.Length; i++)
            {
                Destroy(drone[i]);
                
            }

            textGameEnding.enabled = true;
            textGameEnding.text = ("You WON!!!");
            
            
        }

    }
        
        
    

    //https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
   void wakeUp()
    {
        wakeup = true;
        
        playerAnimation.SetBool("wakeup", true);

        Invoke("standUp", 1.3f);

    }

    void standUp()
    {
        faint = false;
        
        playerAnimation.SetBool("faint", false);

        wakeup = false;

        playerAnimation.SetBool("wakeup", false);

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "timecube")
        {

            //timer.bonusTime = 5.0f;


        }


    }
    

}
