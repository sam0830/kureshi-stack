using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager> {

	private const string TITLE_BGM = "TitleBGM";

	private void Start() {
		AudioManager.Instance.PlayBGM (TITLE_BGM, AudioManager.BGM_FADE_SPEED_RATE_HIGH);
	}

	private void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}

	public void LoadGameScene() {
		SceneManager.LoadScene("game");
	}

	public void LoadTitleScene() {
		SceneManager.LoadScene("title");
	}

	/*
	public void LoadGamaOverScene() {
		AudioManager.Instance.FadeOutBGM();
		SceneManager.LoadScene("gameover");
	}
	*/

	public void LoadHowToScene() {
		SceneManager.LoadScene("howto");
	}

	public void LoadHighScoreScene() {
		SceneManager.LoadScene("highscore");
	}
}
