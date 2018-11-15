using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using Common;

public class UserAuthManager : SingletonMonoBehaviour<UserAuthManager> {
	private string _currentUserId;

	override protected void Awake() {
		base.Awake();
		DontDestroyOnLoad(this.gameObject);
	}

	public void LogIn( string id, string pw, System.Action callback) {
		NCMBUser.LogInAsync (id, pw, (NCMBException e) => {
   			// 接続成功したら
   			if( e == null ){
	 			_currentUserId = id;
				NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
	      		query.WhereEqualTo ("userId", id);
	      		query.FindAsync ((List<NCMBObject> objList ,NCMBException queryE) => {
					if( queryE == null ){
						// PlayerPrefsのハイスコアを登録
						if( objList.Count == 0 ) {
							NCMBObject obj = new NCMBObject("HighScore");
							obj["highScore"] = PlayerPrefs.GetInt(Constant.HIGH_SCORE_KEY, 0);
							obj.SaveAsync();
						}
					}
			  	});
				callback();
   			}
   		});
 	}

	public void SignUp(string id, string pw, System.Action callback) {
		NCMBUser user = new NCMBUser();
		user.UserName = id;
	    user.Password = pw;
		user.SignUpAsync((NCMBException e) => {
			if(e!= null) {
				if(e.ErrorMessage == "userName is duplication.") {
					PlatformDialog.SetButtonLabel("OK");
					PlatformDialog.Show(
						"エラー",
						"既にIDが登録されています",
						PlatformDialog.Type.SubmitOnly,
						() => {
							Debug.Log("OK");
						},
						null
					);
				}
				return;
			}
			_currentUserId = id;
			PlayerPrefs.SetString(Constant.USER_ID_KEY, id);
			PlayerPrefs.SetString(Constant.USER_PASS_KEY, pw);
			NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
      		query.WhereEqualTo ("userId", id);
      		query.FindAsync ((List<NCMBObject> objList ,NCMBException queryE) => {
				if( queryE == null ){
					// PlayerPrefsのハイスコアを登録
					if( objList.Count == 0 ) {
						NCMBObject obj = new NCMBObject("HighScore");
						obj["userId"]  = id;
						obj["highScore"] = PlayerPrefs.GetInt(Constant.HIGH_SCORE_KEY, 0);
						obj.SaveAsync();
					}
				}
		  	});
			callback();
      	});
	}

	public void LogOut() {
	    NCMBUser.LogOutAsync ( (NCMBException e) => {
		    if( e == null ){
		      _currentUserId = null;
		    }
    	});
  	}

	public string GetCurrentUserId() {
    	return _currentUserId;
  	}

	public bool IsLogIn() {
		if(_currentUserId==""||_currentUserId==null) {
			return false;
		}
		return true;
	}
}
