using UnityEngine;

public class EnemyExampleScript : MonoBehaviour
{
    [SerializeField]
    bool isActive = false;

    [SerializeField]
    private float minDistance;

    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        // Check if player is in range
        // if player is in range set isActive to true
        // otherwise set isActive to false

        if(Vector3.Distance(transform.position, playerTransform.position) <= minDistance)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        if (isActive == false)
            return;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
