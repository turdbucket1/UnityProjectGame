using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCubes : MonoBehaviour
{

    [SerializeField] public Vector3 RotationAxis;

    [SerializeField] public player player;

    [SerializeField] public textTimer timer;

    public GameObject Player;

    AudioSource soundCube;


    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");

        soundCube = GameObject.Find("pickup").GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        float rotationAngle = 60.0f * Time.deltaTime;

        transform.Rotate(RotationAxis, rotationAngle);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
          
                Destroy(gameObject);

                soundCube.Play();

                timer.bonusTime = 5.0f;



        }


    }
}
