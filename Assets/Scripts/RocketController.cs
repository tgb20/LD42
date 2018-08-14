using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {


    public Vector3 destination;

    public Vector3 startScale;

    public Vector3 endScale;

    public float speed;

    public GameObject[] trash;

    private bool spawnedPayload;


    public GameObject[] shells;


	// Use this for initialization
	void Start () {
        transform.LookAt(2 * transform.position - Vector3.zero);
        transform.localScale = startScale;
	}
	
	// Update is called once per frame
	void Update () {

        if (!spawnedPayload)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            transform.localScale = Vector3.Lerp(transform.localScale, endScale, Time.deltaTime * speed);
        }


        if(transform.position == destination && !spawnedPayload){


            GameObject trashObj = trash[Random.Range(0, trash.Length)];


            Instantiate(trashObj, transform.position, Quaternion.identity);

            spawnedPayload = true;



        }


        if(spawnedPayload){
            for (int i = 0; i < shells.Length; i++)
            {
                if (shells[i] != null)
                {
                    shells[i].transform.parent = null;
                    shells[i] = null;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * speed);
            transform.localScale = Vector3.Lerp(transform.localScale, startScale, Time.deltaTime * speed/2);
        }

        if(transform.position == Vector3.zero){
            Destroy(gameObject);
        }



	}
}
