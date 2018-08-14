using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {


    private float angle;

    public float rotationSpeed;

	void Update () {


        Vector2 mousePos = Input.mousePosition;

        float sWidth = Camera.main.scaledPixelWidth;
        float sHeight = Camera.main.scaledPixelHeight;

        Vector2 screenCenter = new Vector2(sWidth / 2, sHeight / 2);


        angle = Mathf.Atan2(mousePos.y - screenCenter.y, mousePos.x - screenCenter.x) * 180 / Mathf.PI + -90;

	}

	private void FixedUpdate()
	{
        Vector3 newRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);


        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(newRotation), Time.deltaTime * rotationSpeed);

	}
}
