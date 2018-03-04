using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreButton : MonoBehaviour {
	public void OnClick() {
		GameSceneManager.Instance.LoadHighScoreScene();
	}
}
