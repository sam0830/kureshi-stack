using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToButton : MonoBehaviour {

	public void OnClick() {
		GameSceneManager.Instance.LoadHowToScene();
	}
}
