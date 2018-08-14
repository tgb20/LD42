using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDetector : MonoBehaviour {


    public bool touchingTrash;

    public GameObject explosion;

    public float safeTime;

	private void Update()
	{
        if(safeTime > 0){
            safeTime -= Time.deltaTime; 
        }
	}


	private void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.tag == "Trash" || other.gameObject.tag == "Clump"){

            if(safeTime >= 0){
                Destroy(other.gameObject);
            }else{
                touchingTrash = true;
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
	}



}
