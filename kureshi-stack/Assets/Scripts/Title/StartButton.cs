using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using Common;

public class StartButton : MonoBehaviour {

	public void OnClick() {
		AudioManager.Instance.PlaySE(Constant.Start_SE);
	   	GameSceneManager.Instance.LoadGameScene();
	}
	/*
	private void OnEnable() {
	    // TapGestureのdelegateに登録
	    GetComponent<TapGesture>().Tapped += TappedHandle;
	}

	private void OnDisable() {
	    UnsubscribeEvent();
	}

	private void OnDestroy() {
	    UnsubscribeEvent();
	}

	private void UnsubscribeEvent() {
	    // 登録を解除
	    GetComponent<TapGesture>().Tapped -= TappedHandle;
	}

	private void TappedHandle(object sender, System.EventArgs e) {
	    //処理したい内容
	    AudioManager.Instance.PlaySE(Constant.Start_SE);
	   	GameSceneManager.Instance.LoadGameScene();
	}
	*/
}
