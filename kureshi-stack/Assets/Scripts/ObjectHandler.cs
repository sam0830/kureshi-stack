using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using TouchScript.Hit;

public class ObjectHandler : MonoBehaviour {
	[SerializeField]
	private Vector3 CENTER_OF_GRAVITY = new Vector3(0f,0f,0f);
	private Rigidbody2D rigidboy2D;

	private void Start() {
		rigidboy2D = GetComponent<Rigidbody2D>();
		rigidboy2D.centerOfMass = CENTER_OF_GRAVITY;
	}

	private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere (transform.position + transform.rotation * CENTER_OF_GRAVITY, 0.1f);
    }

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
