using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {


    public float speed;
    public Transform target;


	private void FixedUpdate()
	{
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
	}
}
