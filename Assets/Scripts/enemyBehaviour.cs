using UnityEngine;
using UnityEngine.AI;

public class enemyBehaviour : MonoBehaviour
{
    // [SerializeField] GameObject target;
    public float closeDistance = 10f;

    void Update()
    {
        FindClosestBuilding();
        GetComponent<NavMeshAgent>().destination = FindClosestBuilding().transform.position;
    }

    public GameObject FindClosestBuilding()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Building");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
