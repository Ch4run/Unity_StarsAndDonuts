using System.Collections;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] private Star star;
    [SerializeField] private int starCount = 256;
    private float xBound = 8.9f;
    private float yBound = 5f;
    private Vector2 screenBounds = new Vector2(8.9f, 5f);
    private float localScaleMin = 0.1f;
    private float localScaleMax = 1.2f;
    [SerializeField] Star[] stars;

    private void Awake()
    {
        StarsArrayInitializer();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        Application.Quit();
    //    }
    //}

    private void StarsArrayInitializer()
    {
        stars = new Star[starCount];
        for (int i = 0; i < starCount; i++)
        {
            // spawnig the whole swarm out of the sight, then reposition & rescale later
            Star newStar = Instantiate(star, new Vector3(64f, 64f, 64f), Quaternion.identity);
            stars[i] = newStar;
        }
        StartCoroutine(WaitBetweenStarUpdate());
    }

    IEnumerator WaitBetweenStarUpdate()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetPosition(new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y)));
            stars[i].SetLocalScale(Random.Range(localScaleMin, localScaleMax));
            yield return new WaitForSeconds(0.04f);
        }
        StartCoroutine(WaitBetweenStarUpdate());
    }
}
