using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class battery : MonoBehaviour
{

    [SerializeField] public player player;

    [SerializeField] public TMP_Text textBattery;
    
    [SerializeField] public AudioSource soundBattery;

    public GameObject Player;

    public Light purpleLight;

    public bool batteryActive;

    

    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        soundBattery = GameObject.Find("Battery").GetComponent<AudioSource>();

        batteryActive = true;

        textBattery.enabled = false;

        Light purpleLight = gameObject.GetComponent<Light>();

        soundBattery.Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.tag == "Player") && (batteryActive == true))
        {
            textBattery.enabled = true;
            

        }

        if ((other.gameObject.tag == "Player") && (batteryActive == false))
        {
            textBattery.enabled = false;
            

        }


    }

    public void OnTriggerStay(Collider other)
    {
        

        if ((other.gameObject.tag == "Player") && (Input.GetKey(KeyCode.Space) && (batteryActive == true)))
        {
                batteryActive = false;
                soundBattery.Stop();
                purpleLight.enabled = false;
                textBattery.enabled = false;
                player.d = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            textBattery.enabled = false;
            

        }

    }

}
