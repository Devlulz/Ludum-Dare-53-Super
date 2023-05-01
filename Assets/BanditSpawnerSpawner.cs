using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditSpawnerSpawner : MonoBehaviour
{
    [SerializeField]
    float spawnTimer = 10f;
    [SerializeField]
    int numOfEnemies;
    [SerializeField]
    GameObject banditSpawner;
    [SerializeField]
    Transform jumpPoint;

    private void Update()
    {
        spawnTimer -= .01f;
        if(spawnTimer < 0)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        numOfEnemies = Random.Range(1, 4);
        for (int i = 0; i < numOfEnemies; i++)
        {
            GameObject banditSpawn = Instantiate(banditSpawner, transform.position + new Vector3(Random.Range(0f, 4f),.5f,0), transform.rotation);
            banditSpawn.GetComponent<BanditSpawner>().jumpPoint = jumpPoint;
        }
        ResetTimer();
    }

    void ResetTimer()
    {
        spawnTimer = Random.Range(100f, 300f);
    }
}
