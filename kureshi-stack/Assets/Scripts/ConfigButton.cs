using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigButton : MonoBehaviour {

	[SerializeField]
	private Canvas configModalWindow;
	[SerializeField]
	private Slider bgmSlider;
	[SerializeField]
	private Slider seSlider;

	private void Start() {
		if(bgmSlider == null) {
			bgmSlider = GameObject.Find("ConfigModalWindow/BGMSlider").GetComponent<Slider>();
		}
		if(seSlider == null) {
			seSlider = GameObject.Find("ConfigModalWindow/SESlider").GetComponent<Slider>();
		}
		if(configModalWindow == null) {
			configModalWindow = GameObject.Find("ConfigModalWindow").GetComponent<Canvas>();
		}
		// TODO:PlayerPrefsから音量を取得してSliderにセット
		configModalWindow.enabled = false;
	}

	private void ShowConfigModalWindow() {
		if(configModalWindow != null) {
			configModalWindow.enabled = true;
		}
	}

	public void OnClick() {
		AudioManager.Instance.FadeOutBGM();
		ShowConfigModalWindow();
	}
}
