using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class ReturnButton : MonoBehaviour {
	[SerializeField]
	private Canvas configModalWindow;

	private void Start() {
		if(configModalWindow == null) {
			configModalWindow = GameObject.Find("ConfigModalWindow").GetComponent<Canvas>();
		}
	}

	public void OnClick() {
		TitleViewManager.Instance.EnableButtons();
		AudioManager.Instance.PlayBGM(Constant.TITLE_BGM);
		configModalWindow.enabled = false;
	}
}
