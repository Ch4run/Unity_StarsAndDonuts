using UnityEngine;

public class Star : MonoBehaviour
{
    public void SetPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void SetLocalScale(float newScale)
    {
        transform.localScale = new Vector2(newScale, newScale);
    }
}