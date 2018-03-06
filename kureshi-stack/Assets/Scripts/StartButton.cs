﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class StartButton : MonoBehaviour {

	private const string Start_SE = "StartSE";

	private void OnEnable() {
	    // TapGestureのdelegateに登録
	    GetComponent<TapGesture>().Tapped += tappedHandle;
	}

	private void OnDisable() {
	    UnsubscribeEvent();
	}

	private void OnDestroy() {
	    UnsubscribeEvent();
	}

	private void UnsubscribeEvent() {
	    // 登録を解除
	    GetComponent<TapGesture>().Tapped -= tappedHandle;
	}

	private void tappedHandle(object sender, System.EventArgs e) {
	    //処理したい内容
	    AudioManager.Instance.PlaySE(Start_SE);
	   	GameSceneManager.Instance.LoadGameScene();
	}
}
