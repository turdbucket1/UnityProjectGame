using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class drone : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public player Player;
    [SerializeField] private Transform[] pointsNavigation = new Transform[3];

    private NavMeshAgent agentIA;
    private int destination;


    // Start is called before the first frame update
    void Start()
    {
        agentIA = GetComponent<NavMeshAgent>();

        destination = 0;

        agentIA.SetDestination(pointsNavigation[destination].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Utilitaires.ObjetVisible(gameObject, player, 40, 5))
        {
            player.GetComponent<player>().faint = true;
      
        }

        if (!agentIA.pathPending && (agentIA.remainingDistance <= agentIA.stoppingDistance))
        {
            // destination atteinte, on passe à la prochaine destination
            destination++;
            if (destination == pointsNavigation.Length)
            {
                destination = 0;
            }

            agentIA.SetDestination(pointsNavigation[destination].position);
        }

        if (Input.GetKey(KeyCode.P))
        {
            Destroy(gameObject);

        }

       

    }
}
