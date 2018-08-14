using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMessage : MonoBehaviour {


    public string message;
    public string userName;

    public Sprite icon;

    public Text messageText;
    public Text userNameText;
    public Image profilePic;



	// Use this for initialization
	void Start () {
        messageText.text = message;
        userNameText.text = userName;
        profilePic.sprite = icon;
	}
}
