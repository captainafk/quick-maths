using UnityEngine;

public class Obstacle2_Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn = 3f;
    public float decreaseTime = 0.01f;
    public float minTime = 0.5f;
    private GameObject randomObstaclePattern;

    private void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            randomObstaclePattern = Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;

            if (startTimeBetweenSpawn > minTime)
            {
                startTimeBetweenSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }

        Destroy(randomObstaclePattern, 1.0f);
    }
}