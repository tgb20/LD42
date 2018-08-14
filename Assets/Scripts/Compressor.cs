using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compressor : MonoBehaviour {

    private GrabberDetector grabber;

    private bool holdingCompressed;

    private bool holdingClump;

    private GameObject newTrash;

    public float percentBySize;

    public GameObject compressedTrash;

    private bool mouseIsDown;

    private float originalTurnSpeed;
    private float originalShipSpeed;

    private PlayerMovement pMove;
    private LookAtMouse lMouse;

    public Animator robotAnim;

	private void Start()
	{
        grabber = GetComponentInChildren<GrabberDetector>();
        pMove = GetComponentInParent<PlayerMovement>();
        lMouse = GetComponent<LookAtMouse>();
        originalShipSpeed = pMove.speed;
        originalTurnSpeed = lMouse.rotationSpeed;
	}


	// Update is called once per frame
	void Update () {


        if(holdingClump){

            float clumpSize = grabber.clump.GetComponentsInChildren<Clumper>().Length;

            float percentOff = clumpSize * percentBySize;

            pMove.speed = originalShipSpeed - (originalShipSpeed * (percentOff / 100));

            lMouse.rotationSpeed = originalTurnSpeed - (originalTurnSpeed * (percentOff / 100));




        }

        if(!holdingClump){
            pMove.speed = originalShipSpeed;
            lMouse.rotationSpeed = originalTurnSpeed;
        }

		

        if(grabber.touchingTrash && Input.GetMouseButtonDown(0) && !holdingCompressed && !holdingClump && !mouseIsDown){

            Destroy(grabber.trashObj);

            Vector3 trashPos = new Vector3(0, 1, 0);

            robotAnim.SetTrigger("grab");

            grabber.gameObject.GetComponent<AudioSource>().Play();

            newTrash = Instantiate(compressedTrash);
            newTrash.transform.parent = transform;
            newTrash.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newTrash.transform.localPosition = trashPos;
            mouseIsDown = true;
            holdingCompressed = true;

        }

        if(grabber.touchingClump && Input.GetMouseButtonDown(0) && !holdingClump && !holdingCompressed && !mouseIsDown){
            grabber.clump.transform.parent = transform;
            mouseIsDown = true;
            holdingClump = true;
        }


        if(Input.GetMouseButtonDown(0) && holdingCompressed && !mouseIsDown){
            newTrash.transform.parent = null;
            newTrash = null;
            holdingCompressed = false;
            grabber.touchingTrash = false;
            grabber.trashObj = null;
            mouseIsDown = true;
        }

        if(Input.GetMouseButtonDown(0) && holdingClump && !mouseIsDown){
            grabber.clump.transform.parent = null;
            grabber.touchingClump = false;
            grabber.clump = null;
            holdingClump = false;
            mouseIsDown = true;
        }



        if(Input.GetMouseButtonUp(0)){
            mouseIsDown = false;
        }

        if (newTrash != null && newTrash.transform.parent != transform && holdingCompressed == true){
            newTrash = null;
            holdingCompressed = false;
            grabber.touchingTrash = false;
            grabber.trashObj = null;
        }

        if (grabber.clump != null && grabber.clump.transform.parent != transform && holdingClump == true)
        {
            grabber.clump = null;
            newTrash = null;
            holdingClump = false;
            grabber.touchingClump = false;
        }


	}
}
