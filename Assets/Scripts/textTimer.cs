using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textTimer : MonoBehaviour
{
    public TMP_Text txtTimer;
    public float startingTimer;
    public float time;
    public float bonusTime;

    [SerializeField] public player player;

    [SerializeField] public textBatteriesLeft txtBatteriesLeft;


    // Start is called before the first frame update
    void Start()
    {

        startingTimer = 120.0f;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0f)
        {
                time = startingTimer - Time.time + bonusTime;

            string mins = ((int)time / 60).ToString("00");

            string secs = (time % 60).ToString("00");

            txtTimer.text = mins + ":" + secs;


        }
        


        if (time <= 0f)
        {
            
            player.playerAnimation.SetBool("move", false);

            player.door.SetActive(true);

            Debug.Log("hi");


            player.textGameEnding.enabled = true;
            player.textGameEnding.text = ("You LOST");
            

        }

        if (player.numBatteries == 0)
        {
            txtTimer.enabled = false;
            
        }
    }
}
