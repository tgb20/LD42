using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteSpawner : MonoBehaviour {


    public GameObject satellite;

    public float interval;

    private void Start()
    {
        InvokeRepeating("SpawnSatellite", interval, interval);
    }



    private void SpawnSatellite()
    {
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameUIManager>().makeMessage("good");
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameUIManager>().HQTweet("good");
        Instantiate(satellite, Vector3.zero, Random.rotation);

    }
}
