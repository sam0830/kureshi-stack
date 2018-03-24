using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager> {
	public enum PlayType {
		PLAY,
		PAUSE
	}

	[SerializeField] Canvas confirmDialog;

	private PlayType _ePlayType = PlayType.PLAY;

	public PlayType ePlayType {
		get { return _ePlayType; }
		set { _ePlayType = value; }
	}

	private void Start() {
		AudioManager.Instance.PlayBGM (Constant.TITLE_BGM, AudioManager.BGM_FADE_SPEED_RATE_HIGH);
		confirmDialog.enabled = false;
	}

	private void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}

	private void Update() {
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// ダイアログを表示
			confirmDialog.enabled = true;
			Time.timeScale = 0f;
			_ePlayType = PlayType.PAUSE;
			return;
		}
#else
		// プラットフォームがアンドロイドかチェック
		if (Application.platform == RuntimePlatform.Android) {
		    // エスケープキー取得
		    if (Input.GetKeyDown(KeyCode.Escape)) {
		        // ダイアログを表示
		        confirmDialog.enabled = true;
				Time.timeScale = 0f;
				_ePlayType = PlayType.PAUSE;
		        return;
		    }
		}
#endif
	}

	public void LoadGameScene() {
		SceneManager.LoadScene("game");
	}

	public void LoadTitleScene() {
		SceneManager.LoadScene("title");
	}

	public void LoadHowToScene() {
		SceneManager.LoadScene("howto");
	}

	public void LoadHighScoreScene() {
		SceneManager.LoadScene("highscore");
	}

	public void SetConfirmDialogEnabled(bool flag = false) {
		confirmDialog.enabled = flag;
	}
}
