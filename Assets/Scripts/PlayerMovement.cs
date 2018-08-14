using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {



    public float speed;
    public Transform robot;
    public float ramp;

    public GameObject thrusters;
    public Vector3 boostPos;


    private float horzInput;
    private float vertInput;

    private float baseSpeed;

    private Vector3 lastSpeedVec;

    private Vector3 thrustStart;

	// Use this for initialization
	void Start () {
        thrustStart = thrusters.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        horzInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horzInput) > 0.1f || Mathf.Abs(vertInput) > 0.1f)
        {
            lastSpeedVec = new Vector3(vertInput, -horzInput);
        }

	}


	private void FixedUpdate()
    {

        if(baseSpeed < speed && (Mathf.Abs(horzInput) > 0.1f || Mathf.Abs(vertInput) > 0.1f)){
            baseSpeed += ramp;
            thrusters.transform.localPosition = Vector3.Lerp(boostPos, thrustStart, 0.001f * Time.deltaTime);
        }

        if(Mathf.Abs(horzInput) < 0.1 && Mathf.Abs(vertInput) < 0.1 && baseSpeed >= 0){
            baseSpeed -= ramp;
            thrusters.transform.localPosition = Vector3.Lerp(thrustStart, boostPos, 0.001f * Time.deltaTime);
        }

        transform.Rotate(lastSpeedVec.normalized * baseSpeed * Time.deltaTime);

	}

}
