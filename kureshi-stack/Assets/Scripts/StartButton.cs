using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public void OnClick() {
		Debug.Log("ボタンを押した");
		GameSceneManager.Instance.LoadGameScene();
	}
}
