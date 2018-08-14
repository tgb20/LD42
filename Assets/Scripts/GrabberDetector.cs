using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberDetector : MonoBehaviour {


    public bool touchingTrash;

    public GameObject trashObj;

    public bool touchingClump;

    public GameObject clump;

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Trash"){
            touchingTrash = true;
            trashObj = other.gameObject;
        }
        if(other.tag == "Clump"){
            touchingClump = true;
            clump = other.transform.root.gameObject;
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if(other.tag == "Trash"){
            touchingTrash = false;
            trashObj = null;
        }
        if (other.tag == "Clump")
        {
            touchingClump = false;
            clump = null;
        }
	}

}
