using UnityEngine;

public class Donut : MonoBehaviour
{
    private Transform destination;
    private float speed = 1f;

    public void SetDestination(Transform newDestination)    // gets the destination point from the DonutManager
    {
        destination = newDestination;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        if(transform.position == destination.position)
        {
            DonutManager.instance.Spawner();
            Destroy(gameObject);
        }
    }
}
