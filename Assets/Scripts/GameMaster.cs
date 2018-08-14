using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int health;
    public int stations;

    public GameObject endGamePanel;
    public Text highScoreText;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        AudioListener.volume = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if(GameObject.FindGameObjectsWithTag("Sat").Length > stations){
            stations = GameObject.FindGameObjectsWithTag("Sat").Length;
        }


        if(health == 0){
            StartCoroutine(endGame());

        }



	}


    IEnumerator endGame(){
        endGamePanel.SetActive(true);
        yield return new WaitForSeconds(1);
        highScoreText.enabled = true;
        highScoreText.text = "The most satellites the robot every protected was " + stations;
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }


}
