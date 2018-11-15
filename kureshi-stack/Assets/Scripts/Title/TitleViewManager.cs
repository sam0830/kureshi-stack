using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class TitleViewManager : SingletonMonoBehaviour<TitleViewManager> {
	[SerializeField]
	private GameObject highScoreButton;
	[SerializeField]
	private GameObject configButton;
	[SerializeField]
	private GameObject loginButton;
	[SerializeField]
	private Text userIdLabel;

	[SerializeField]
	private Canvas signUpModalWindow;

	private void Start() {
		if(highScoreButton == null) {
			highScoreButton = transform.Find("HighScoreButton").gameObject;
		}
		if(configButton == null) {
			configButton = transform.Find("ConfigButton").gameObject;
		}
		if(loginButton == null) {
			loginButton = transform.Find("LoginButton").gameObject;
		}
		if(userIdLabel == null) {
			userIdLabel = transform.Find("UserIdLabel").GetComponent<Text>();
		}
		if(signUpModalWindow == null) {
			signUpModalWindow = GameObject.Find("SignUpModalWindow").GetComponent<Canvas>();
			signUpModalWindow.enabled = false;
		}

		//　まだ会員登録していない
		if(PlayerPrefs.GetString(Constant.USER_ID_KEY, "") == "") {Debug.Log(signUpModalWindow );
			if(signUpModalWindow != null) {
				signUpModalWindow.enabled = true;
			}
		}
	}

	public void SetUserIdLabel(string id) {
		userIdLabel.text = id + "さん";
	}

}
