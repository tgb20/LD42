using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCleanUp : MonoBehaviour {



	private void Start()
	{
        StartCoroutine(goAway());
	}


    IEnumerator goAway(){
        yield return new WaitForSeconds(2.5f);

        Destroy(gameObject);
    }


}
