using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSlider : MonoBehaviour {
	private Slider _slider;

	private void Start() {
		_slider = GetComponent<Slider>();
	}

	public void OnValueChanged() {
		SequenceManager.Instance.RoatateModel(_slider.value);
	}
}
