using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	[SerializeField]
	private Text highScoreText;

	private const string PREFIX_STRING = "HighScore\n";

	private void Start() {
		highScoreText = transform.Find("Text").gameObject.GetComponent<Text>();
		highScoreText.text = PREFIX_STRING + ((int)SequenceManager.Instance.GetHighScore()).ToString();
	}

}
