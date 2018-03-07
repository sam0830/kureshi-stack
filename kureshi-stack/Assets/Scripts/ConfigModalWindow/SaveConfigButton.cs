using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveConfigButton : MonoBehaviour {

	private const string TITLE_BGM = "TitleBGM";

	[SerializeField]
	private Slider bgmSlider;
	[SerializeField]
	private Slider seSlider;
	[SerializeField]
	private Canvas configModalWindow;

	private void Start() {
		if(bgmSlider == null) {
			bgmSlider = transform.parent.Find("BGMSlider").GetComponent<Slider>();
		}
		if(seSlider == null) {
			seSlider = transform.parent.Find("SESlider").GetComponent<Slider>();
		}
		if(configModalWindow == null) {
			configModalWindow = GameObject.Find("ConfigModalWindow").GetComponent<Canvas>();
		}
	}

	public void OnClick() {
		// TODO: PlayerPrefsに各パラメータの値を保存
		// AudioManager.Instance.ChangeVolume();
		Debug.Log("BGMの音量"+bgmSlider.value+"を保存");
		Debug.Log("SEの音量"+seSlider.value+"を保存");
		AudioManager.Instance.PlayBGM(TITLE_BGM);
		configModalWindow.enabled = false;
	}
}
