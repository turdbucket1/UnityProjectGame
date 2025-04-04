using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class textBatteriesLeft : MonoBehaviour
{

    [SerializeField] public TMP_Text txtBatteryLeft;

    [SerializeField] public textTimer timer;
    [SerializeField] public battery battery;
    [SerializeField] public player player;
   

    // Start is called before the first frame update
    void Start()
    {
        txtBatteryLeft.text = ("Batteries left: " + player.numBatteries).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if ((battery.batteryActive == true))
            {
                
                Debug.Log("numBatteries -1");

               

            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (battery.batteryActive == false))
        {
            if (player.numBatteries > 1)
            {
                txtBatteryLeft.text = ("Batteries left: " + player.numBatteries).ToString();

                
            }
            
            if (player.numBatteries == 1)
            {
                txtBatteryLeft.text = (" 1 battery left! ").ToString();

               

            }

            if (player.numBatteries == 0)
            {
                
                txtBatteryLeft.enabled = false;
                              

            }


        }
    }

    public void OnTriggerExit(Collider other)
    {
        
    }
}
