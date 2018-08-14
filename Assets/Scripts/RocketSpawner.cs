using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public float earthRadius;
    public float spaceRadius;
    public GameObject[] rockets;
    public float interval;
    public float minSpawnDistance;

    private void Start()
    {
        InvokeRepeating("SpawnRocket", interval, interval);
    }



    private void SpawnRocket()
    {


        Vector3 randomPoint = Random.onUnitSphere;

        Vector3 destination = randomPoint * spaceRadius;

        bool canSpawn = true;

        GameObject[] stations = GameObject.FindGameObjectsWithTag("Station");

        for (int i = 0; i < stations.Length; i++){
            if(Vector3.Distance(destination, stations[i].transform.position) < minSpawnDistance){
                canSpawn = false;
            }
        }


        if (canSpawn)
        {
            GameObject rocketObj = rockets[Random.Range(0, rockets.Length)];

            Vector3 rocketPos = randomPoint * earthRadius;

            rocketObj.GetComponent<RocketController>().destination = destination;

            Instantiate(rocketObj, rocketPos, Quaternion.identity);
        }

    }
}
