using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RestartButton : MonoBehaviour {

	private RectTransform rectTransform;

	private void Start() {
		rectTransform = GetComponent<RectTransform>();
		rectTransform.localPosition = Constant.RESTART_BUTTON_INITIAL_POSITION;
	}

	private void Update() {
		rectTransform.localPosition = Vector3.MoveTowards(
			rectTransform.localPosition,
			Constant.RESTART_BUTTON_TARGET_POSITION,
			300f*Time.deltaTime);
	}
	public void OnClick() {
		Debug.Log("ボタンを押した");
		GameSceneManager.Instance.LoadTitleScene();
	}
}
