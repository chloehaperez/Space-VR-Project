using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 positionRandomization;
    public GameObject player;
    public Vector3 gridOrigin;
    public GameObject trigger;
    public Vector3 frontofPlayer;

    void Start()
    {
        gridOrigin = player.transform.position;
        SpawnGrid();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(gridOrigin, player.transform.position) > 500)
        {
            frontofPlayer = transform.position + (transform.forward * 2);
            gridOrigin = frontofPlayer;
            SpawnGrid();
        }
    }

    void SpawnGrid()
    {
        for (int x = 0; x < gridX / 2; x++)
        {
            for (int z = 0; z < gridZ / 2; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(RandomizedPosition(spawnPosition), Quaternion.identity);
                Vector3 spawnPosition2 = gridOrigin - new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset);
                PickAndSpawn(RandomizedPosition(spawnPosition2), Quaternion.identity);
                Vector3 spawnPosition3 = new Vector3(x * gridSpacingOffset, 0, -z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(RandomizedPosition(spawnPosition3), Quaternion.identity);
                Vector3 spawnPosition4 = new Vector3(-x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(RandomizedPosition(spawnPosition4), Quaternion.identity);
            }
        }
    }

    Vector3 RandomPoint()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        Vector2 v2 = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).normalized;
        return new Vector3(v2.x * 100, Random.Range(-positionRandomization.y, positionRandomization.y), v2.y * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Trigger"))
        {
            gridOrigin = player.transform.position;
            SpawnGrid();
        }*/

        if (Vector3.Distance(gridOrigin, player.transform.position) > 500)
        {
            frontofPlayer = transform.position + (transform.forward * 2);
            gridOrigin = frontofPlayer;
            SpawnGrid();
        }

        Destroy(other.gameObject);
        PickAndSpawn(RandomPoint(), Quaternion.identity);
    }



    Vector3 RandomizedPosition(Vector3 position)
    {
        Vector3 randomizedPosition = new Vector3(Random.Range(-positionRandomization.x, positionRandomization.x), Random.Range(-positionRandomization.y, positionRandomization.y), Random.Range(-positionRandomization.z, positionRandomization.z)) + position;

        return randomizedPosition;

    }

    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}