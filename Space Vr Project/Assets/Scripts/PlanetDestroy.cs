using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class PlanetDestroy : MonoBehaviour
{
    //public GameObject[] itemsToPickFrom;
    public float range = 1000f;
    //public Vector3 positionRandomization;
    // Update is called once per frame
    void Update()
    {
       
        if (Vector3.Distance(gameObject.transform.position, PlayerController.pos) > range)
        {
            Destroy(gameObject);
            //PickAndSpawn(RandomPoint(), Quaternion.identity);
        }
    }
    /*
    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }

    Vector3 RandomPoint()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        Vector2 v2 = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).normalized;
        return new Vector3(v2.x * pos.x, Random.Range(-positionRandomization.y, positionRandomization.y), v2.y * pos.z);
    }*/
}
