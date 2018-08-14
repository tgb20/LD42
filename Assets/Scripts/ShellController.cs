using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour {

    public Vector3 splitTo;
    public float splitSpeed;

	
	// Update is called once per frame
	void Update () {
        if(transform.parent == null){
            transform.Translate(splitTo * splitSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);
            gameObject.GetComponent<ExplosionCleanUp>().enabled = true;
        }
	}
}
