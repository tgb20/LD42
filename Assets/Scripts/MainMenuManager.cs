using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	private void Start()
	{
        Time.timeScale = 1;
        AudioListener.volume = 1;
	}

	public void QuitGame(){
        Application.Quit();
    }


    public void PlayGame(){
        SceneManager.LoadScene("GameScene");
    }

    public void HowTo(){
        SceneManager.LoadScene("HowTo");
    }




}
