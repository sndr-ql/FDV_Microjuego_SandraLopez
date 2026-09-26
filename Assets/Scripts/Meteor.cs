using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public float spawnRatePerMin = 30f;
    public float spawnRateInc = 1f;
    private float spawnNext = 0;
    public float xLimit = 6f;

    public PooledMeteors meteorPool;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60/spawnRatePerMin;
            spawnRatePerMin += spawnRateInc;
            
            float rand = Random.Range(-xLimit, xLimit);

            Vector3 position = new Vector3(rand, 5f, 0f);

            meteorPool.GetMeteor(position);
        }
    }
}
