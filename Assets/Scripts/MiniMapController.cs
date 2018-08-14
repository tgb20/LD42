using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour {


    public GameObject miniRobot;

    public GameObject mainRobot;

    public GameObject miniSat;

    private GameObject[] currentSatellites = {};

    public List<GameObject> spawnSats = new List<GameObject>();

    private Quaternion startRot;

    private int numOfSats;

	// Use this for initialization
	void Start () {
        startRot = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {

        miniRobot.transform.localRotation = mainRobot.transform.localRotation;
        gameObject.transform.localRotation = Quaternion.Inverse(mainRobot.transform.localRotation);



        // Sats

        currentSatellites = GameObject.FindGameObjectsWithTag("Sat");

        if (spawnSats.Count == currentSatellites.Length)
        {
            for (int i = 0; i < currentSatellites.Length; i++){
                spawnSats[i].transform.localRotation = currentSatellites[i].transform.localRotation;
            }
        }else{
            for (int i = 0; i < spawnSats.Count; i++)
            {
                Destroy(spawnSats[i]);
            }

            spawnSats.Clear();

            for (int i = 0; i < currentSatellites.Length; i++)
            {
                GameObject newSat = Instantiate(miniSat, transform);
                newSat.transform.localPosition = Vector3.zero;
                newSat.transform.localRotation = Quaternion.identity;
                spawnSats.Add(newSat);
            }
        }



	}
}
