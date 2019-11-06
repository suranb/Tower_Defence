
using UnityEngine;
using UnityEngine.AI;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject target;

    public float closeDistance = 5f;

    void Update() 
    {
        CheckCloseDistance();    
    }
    public CheckCloseDistance()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Building");

        for(int i = 0; i < taggedObjects.length; i++)
        {
            if(Vector3.Distance(a.transform.position, taggedObjects[i].transform.position) <= closeDistance)
            {
                //This is within your close distance so do whatever close 
                //logic here
                GetComponent<NavMeshAgent>().destination = target.transform.position;        
            }
        }
    }
}
