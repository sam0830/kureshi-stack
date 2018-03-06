using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToButton : MonoBehaviour {

	private const string ICON_SE = "IconSE";

	public void OnClick() {
		AudioManager.Instance.PlaySE(ICON_SE);
		GameSceneManager.Instance.LoadHowToScene();
	}
}
