using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

/**
 * PlayerPrefsからidをとってきて、あればログイン
 * なければ新規会員登録に飛ばす
 */
public class LoginButton : MonoBehaviour {
	void Start () {

	}

	void Update () {

	}

	public void ShowSignUpModalWindow() {

	}

	public void OnClick() {
		AudioManager.Instance.PlaySE(Constant.ICON_SE);
		// すでにログイン済み
		if(UserAuthManager.Instance.GetCurrentUserId() != "" && UserAuthManager.Instance.GetCurrentUserId() != null) {
			PlatformDialog.SetButtonLabel("OK");
			PlatformDialog.Show(
				"ログイン",
				"既にログイン済みです", 
				PlatformDialog.Type.SubmitOnly,
				() => {
					Debug.Log("OK");
				},
				null
			);
			return;
		}
	}
}
