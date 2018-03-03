using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public void OnClick() {
		Debug.Log("ゲーム開始");
		GameSceneManager.Instance.LoadGameScene();
	}
}
