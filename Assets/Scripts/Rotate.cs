using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = 12f;

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, 0f * Time.deltaTime, Space.World);
    }
}