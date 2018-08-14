using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour {


    public float radius;
    public GameObject[] trash;
    public float interval;




	private void Start()
	{
        InvokeRepeating("SpawnTrash", interval, interval);
	}



    private void SpawnTrash(){


        GameObject trashObj = trash[Random.Range(0, 8)];


        Vector3 trashPos = Random.onUnitSphere * radius;


        Instantiate(trashObj, trashPos, Quaternion.identity);

    }



}
