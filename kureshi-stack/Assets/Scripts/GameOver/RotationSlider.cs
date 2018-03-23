using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSlider : MonoBehaviour {
	private Slider slider;

	private void Start() {
		slider = GetComponent<Slider>();
	}

	public void OnValueChanged() {
		SequenceManager.Instance.RotateModel(slider.value);
	}
}
