using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnDelay = 8f;
    public float initialDelay = 2f;
    public float reduceSD = 0.1f;
    public float minRespawnTime = 6f;
    private bool playerDeath = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    public void StartGame()
    {
        /*StartCoroutine(Spawner());*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(initialDelay);

        while(playerDeath)
        {
            Instantiate(Enemy, this.transform);

            yield return new WaitForSeconds(spawnDelay);
            if(spawnDelay > minRespawnTime)
            {
                spawnDelay -= reduceSD;
            }
        }
    }
}
