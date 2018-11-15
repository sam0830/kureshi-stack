using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class ReturnFromSignUpButton : MonoBehaviour {

	[SerializeField]
	private Canvas signUpModalWindow;

	private void Start() {
		if(signUpModalWindow == null) {
			signUpModalWindow = GameObject.Find("SignUpModalWindow").GetComponent<Canvas>();
		}
	}

	public void OnClick() {
		AudioManager.Instance.PlayBGM(Constant.TITLE_BGM);
		signUpModalWindow.enabled = false;
	}
}
