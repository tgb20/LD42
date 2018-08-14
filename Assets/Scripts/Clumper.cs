using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clumper : MonoBehaviour {

    private Transform robot;


	private void Start()
	{
        robot = GameObject.FindGameObjectWithTag("Robot").transform;
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Clump" && transform.parent != robot)
        {
            other.transform.parent = transform;
        }
	}




}
