using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class StalkerAI : MonoBehaviour
{
    public GameObject stalkerdestination;
    public GameObject stalkerEnemy;

    private NavMeshAgent stalkerAgent;

    public Transform Player;

    public static bool isStalking;

    private float timer;

    public float wanderRadius;
    public float wanderTimer;

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {
        if (isStalking == false)
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                stalkerEnemy.GetComponent<Animator>().Play("Walk");
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                stalkerAgent.SetDestination(newPos);
                timer = 0;

                if(newPos.magnitude == 0f)
                {
                    Vector3 newPos2 = RandomNavSphere(transform.position, wanderRadius, -1);
                }
            }
        }
        else
        {
            stalkerEnemy.GetComponent<Animator>().Play("Walk");
            stalkerAgent.SetDestination(stalkerdestination.transform.position);
            transform.LookAt(Player);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(4);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }


}
