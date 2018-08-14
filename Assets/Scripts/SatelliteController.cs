using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour {


    private GameMaster master;

    private Vector3 rotation;

    public float speed;

	// Use this for initialization
	void Start () {
        rotation = new Vector3(Random.value, Random.value, Random.value);
        master = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {

        StationDetector detector = GetComponentInChildren<StationDetector>();


        if(detector.touchingTrash){
            master.health -= 1;
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameUIManager>().makeMessage("bad");
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameUIManager>().HQTweet("bad");
            Destroy(gameObject);
        }

	}

	private void FixedUpdate()
	{
        transform.Rotate(rotation * speed * Time.deltaTime);
	}
}
