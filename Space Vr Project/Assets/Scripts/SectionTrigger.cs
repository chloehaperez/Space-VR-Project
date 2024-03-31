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

    void Start()
    {
        gridOrigin = player.transform.position;
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for (int x = 0; x < gridX/2; x++)
        {
            for (int z = 0; z < gridZ/2; z++)
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
        GameObject leftwall = Instantiate(trigger, new Vector3(gridX / 2, 0, gridZ / 2) + gridOrigin, Quaternion.identity);
        GameObject rightwall = Instantiate(trigger, gridOrigin - new Vector3(gridX / 2, 0, gridZ / 2), Quaternion.identity);
        GameObject frontwall = Instantiate(trigger, new Vector3(-gridX / 2, 0, gridZ / 2) + gridOrigin, Quaternion.identity);
        GameObject backwall = Instantiate(trigger, new Vector3(-gridX / 2, 0, -gridZ / 2) + gridOrigin, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            gridOrigin = player.transform.position;
            SpawnGrid();
        }
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
