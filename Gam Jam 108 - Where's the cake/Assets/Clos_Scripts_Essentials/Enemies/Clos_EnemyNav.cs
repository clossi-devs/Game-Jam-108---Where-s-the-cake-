using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clos_EnemyNav : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The agent this script should move.")]
    public NavMeshAgent agent;
    [Tooltip("The target tag this agent should chase.")]
    public string target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void Chase ()
    {
        ChaseTarget(GetTarget());
    }

    private GameObject GetTarget ()
    {
        return GameObject.FindGameObjectWithTag(target);
    }

    private void ChaseTarget(GameObject go)
    {
        if (go != null) { agent.SetDestination(go.transform.position); }
    }
}
