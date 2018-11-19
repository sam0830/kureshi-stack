using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class UserIdLabel : MonoBehaviour {

	private void Start() {
		if(UserAuthManager.Instance.IsLogIn()) {
			TitleViewManager.Instance.SetUserIdLabel(UserAuthManager.Instance.GetCurrentUserId());
			return;
		}
		// PlayerPrefsに既に登録済み
		if(PlayerPrefs.GetString(Constant.USER_ID_KEY, "") != "" && PlayerPrefs.GetString(Constant.USER_PASS_KEY, "") != "") {
			// 自動ログイン
			UserAuthManager.Instance.LogIn(PlayerPrefs.GetString(Constant.USER_ID_KEY, ""),
								           PlayerPrefs.GetString(Constant.USER_PASS_KEY, ""), ()=>{
											   TitleViewManager.Instance.SetUserIdLabel(UserAuthManager.Instance.GetCurrentUserId());
											  	});
		}
	}

	private void Update() {

	}
}
