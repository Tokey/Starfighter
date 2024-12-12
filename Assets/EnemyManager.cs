using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnDuration;
    public int maxEnemyCount;
    public float spawnTimer;
    public float minSpawnRadius;
    public float maxSpawnRadius;

    public GameObject player;
    int enemiesInScene;

    // Start is called before the first frame update
    void Start()
    {
        TimerReset();
        GetSpawnPos();
    }
    void TimerReset()
    {
        spawnTimer = spawnDuration;
    }


    // Update is called once per frame
    void Update()
    {
        spawnTimer-=Time.deltaTime;
        //enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy").Length;

        foreach (GameObject enemy in enemies) {
            if (enemy.GetComponent<Plane>().Health <= 0)
            {
                enemy.transform.position = GetSpawnPos();
                enemy.GetComponent<Plane>().Dead = false;
                enemy.GetComponent<Plane>().Health = 100;
                enemy.GetComponent<Plane>().deathEffect.SetActive(false);


                spawnTimer = spawnDuration;
            } 
        }
    }

    Vector3 GetSpawnPos()
    {
        float dist = Random.Range(minSpawnRadius, maxSpawnRadius);
        float angle = Random.Range(0, 360);

        Vector3 spawnPos = CalculateDistantPoint(player.transform.position, dist, angle);
        return spawnPos;    
    }

    public Vector3 CalculateDistantPoint(Vector3 playerPosition, float distance, float angle)
    {
        float angleRad = Mathf.Deg2Rad * angle;
        float xOffset = distance * Mathf.Cos(angleRad);
        float zOffset = distance * Mathf.Sin(angleRad);

        return new Vector3(playerPosition.x + xOffset, playerPosition.y+1000, playerPosition.z + zOffset);
    }

    public void SpawnNavMeshAgent(GameObject agentPrefab, Vector3 desiredPosition)
    {
        Instantiate(agentPrefab, desiredPosition, Quaternion.identity);
    }




}
