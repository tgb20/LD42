using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {


    private Light light;

    private float intensity;

	private void Start()
	{
        light = GetComponent<Light>();
	}


	// Update is called once per frame
	void Update () {

        intensity = Mathf.PingPong(Time.time * 4, 2);

        light.intensity = intensity;



	}
}
