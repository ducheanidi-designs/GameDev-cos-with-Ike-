using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform[] wayPoints;

    [SerializeField] private bool inRange;

    [SerializeField] private float dis;

    [SerializeField] private float disToPlayer;

    public int wayP = 0;

    public int randNum;

    void Start()
    {
        randNum = Random.Range(0, wayPoints.Length);
    }

    void Update()
    {
        CheckPlayerDis();
        wayP = randNum;

        dis = Vector3.Distance (transform.position, wayPoints[wayP].position);

        if (!inRange)
        {
            agent.SetDestination(wayPoints[wayP].position);

            if (dis < 5)
            {
                Debug.Log("Turn");
                randNum = Random.Range(0, wayPoints.Length);
              
            }
        }    

        else
        {
            agent.SetDestination(target.position);
        }                                                                                                                                    

    }

    void CheckPlayerDis()
    {
        disToPlayer = Vector3.Distance(transform.position, target.position);

        if (disToPlayer < 10)
        {
            inRange = true;
        }
    }
}
