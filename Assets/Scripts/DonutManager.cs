using UnityEngine;

public class DonutManager : MonoBehaviour
{
    public static DonutManager instance;    // singleton for reachnig its spawner script by leaving donuts

    [SerializeField] private Donut[] donuts;
    [SerializeField] private Transform[] positions_A;
    [SerializeField] private Transform[] positions_B;
    private int donutsIndex, positionIndex;
    private bool isA;
    private int lastPositionIndex, lastDonutIndex;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Invoke("Spawner", 2);
    }

    public void Spawner()
    {
        donutsIndex = Random.Range(0, donuts.Length);
        // every single time a different spawnpoint from the latest
        do
        {
            positionIndex = Random.Range(0, positions_A.Length);
        }
        while (positionIndex == lastPositionIndex);
        lastPositionIndex = positionIndex;

        // routing
        isA = positionIndex % 2 == 0;
        if (isA)
        {
            Donut newDonut = Instantiate(donuts[donutsIndex], positions_A[positionIndex].transform.position, Quaternion.identity);
            newDonut.SetDestination(positions_B[positionIndex].transform);
        }
        else
        {
            Donut newDonut = Instantiate(donuts[donutsIndex], positions_B[positionIndex].transform.position, Quaternion.identity);
            newDonut.SetDestination(positions_A[positionIndex].transform);
        }
    }
}
