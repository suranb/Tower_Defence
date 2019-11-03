using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(target);
    }
}
