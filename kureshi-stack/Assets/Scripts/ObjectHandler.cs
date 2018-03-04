using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using TouchScript.Hit;

public class ObjectHandler : MonoBehaviour {
	/**
	 * 初期位置
	 */
	private Vector3 _initialPosition;

	private void OnEnable() {
	    // Transform Gestureのdelegateに登録
	    GetComponent<TransformGesture>().TransformStarted+= TransformStartedHandle; // 変形開始
	    GetComponent<TransformGesture>().StateChanged+= StateChangedHandle; //　状態変化
	    GetComponent<TransformGesture>().TransformCompleted+= TransformCompletedHandle; // 変形終了
	    GetComponent<TransformGesture>().Cancelled+= CancelledHandle; // キャンセル
	}

	private void OnDisable() {
	    UnsubscribeEvent();
	}

	private void OnDestroy() {
	    UnsubscribeEvent();
	}

	private void UnsubscribeEvent() {
	    // 登録を解除
	    GetComponent<TransformGesture>().TransformStarted -= TransformStartedHandle;
	    GetComponent<TransformGesture>().StateChanged -= StateChangedHandle;
	    GetComponent<TransformGesture>().TransformCompleted -= TransformCompletedHandle;
	    GetComponent<TransformGesture>().Cancelled -= CancelledHandle;
	}

	private void TransformStartedHandle(object sender, System.EventArgs e) {
	// 変形開始のタッチ時の処理
	}

	private void StateChangedHandle(object sender, System.EventArgs e) {
	// 変形中のタッチ時の処理

	}

	private void TransformCompletedHandle(object sender, System.EventArgs e) {
	// 変形終了のタッチ時の処理
	}

	private void CancelledHandle(object sender, System.EventArgs e) {
	// 変形終了のタッチ時の処理
	}
}
