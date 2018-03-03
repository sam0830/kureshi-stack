using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {
	public void OnClick() {
		Debug.Log("ボタンを押した");
		GameSceneManager.Instance.LoadTitleScene();
	}
}
