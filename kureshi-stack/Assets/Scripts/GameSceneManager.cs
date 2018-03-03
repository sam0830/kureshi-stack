using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager> {

	private void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}

	public void LoadGameScene() {
		SceneManager.LoadScene("game");
	}

	public void LoadTitleScene() {
		SceneManager.LoadScene("title");
	}

	public void LoadGamaOverScene() {
		SceneManager.LoadScene("gameover");
	}
}
