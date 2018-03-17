using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class HighScore : MonoBehaviour {
	[SerializeField]
	private Text highScoreText;

	private RectTransform rectTransform;

	private void Start() {
		highScoreText = transform.Find("Text").gameObject.GetComponent<Text>();
		highScoreText.text = Constant.HIGH_SCORE_PREFIX_STRING + ((int)SequenceManager.Instance.CurrentHighScore).ToString();
		rectTransform = GetComponent<RectTransform>();
		rectTransform.localPosition = Constant.HIGH_SCORE_TEXT_INITIAL_POSITION;
	}

	private void Update() {
		rectTransform.localPosition = Vector3.MoveTowards(
			rectTransform.localPosition,
			Constant.HIGH_SCORE_TEXT_TARGET_POSITION,
			300f*Time.deltaTime);
	}

}
