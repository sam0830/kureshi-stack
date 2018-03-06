using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveConfigButton : MonoBehaviour {

	private const string TITLE_BGM = "TitleBGM";

	[SerializeField]
	private Slider BGMSlider;
	[SerializeField]
	private Slider SESlider;
	[SerializeField]
	private Canvas configModalWindow;

	private void Start() {
		if(BGMSlider == null) {
			BGMSlider = transform.parent.Find("BGMSlider").GetComponent<Slider>();
		}
		if(SESlider == null) {
			SESlider = transform.parent.Find("SESlider").GetComponent<Slider>();
		}
		if(configModalWindow == null) {
			configModalWindow = GameObject.Find("ConfigModalWindow").GetComponent<Canvas>();
		}
	}

	public void OnClick() {
		// TODO: PlayerPrefsに各パラメータの値を保存
		Debug.Log("BGMの音量"+BGMSlider.value+"を保存");
		Debug.Log("SEの音量"+SESlider.value+"を保存");
		AudioManager.Instance.PlayBGM(TITLE_BGM);
		configModalWindow.enabled = false;
	}
}
