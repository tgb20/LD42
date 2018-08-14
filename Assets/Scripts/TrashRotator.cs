using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRotator : MonoBehaviour {


    public float rotationSpeed;

    private Vector3 rotation;

	private void Start()
	{
        rotation = new Vector3(Random.value, Random.value, Random.value);
        transform.localRotation = Random.rotation;
	}

    private void FixedUpdate()
    {
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }

}
