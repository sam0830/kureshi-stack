using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using Common;

public class SignUpButton : MonoBehaviour {
	[SerializeField]
	private InputField idInputField;
	[SerializeField]
	private InputField passInputField;
	[SerializeField]
	private Canvas signUpModalWindow;

	void Start () {
		if(idInputField == null) {
			idInputField = transform.parent.Find("IdInputField").GetComponent<InputField>();
		}
		if(passInputField == null) {
			passInputField = transform.parent.Find("PassInputField").GetComponent<InputField>();
		}
		if(signUpModalWindow == null) {
			signUpModalWindow = GameObject.Find("SignUpModalWindow").GetComponent<Canvas>();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnClick() {
		AudioManager.Instance.PlaySE(Constant.ICON_SE);
		if(idInputField.text == "" || passInputField.text == "") {
			return;
		}
		// idとpassが入力されている
		UserAuthManager.Instance.SignUp(idInputField.text, passInputField.text, ()=>{
			TitleViewManager.Instance.SetUserIdLabel(idInputField.text);
			signUpModalWindow.enabled = false;
			TitleViewManager.Instance.EnableButtons();
			});

	}
}
