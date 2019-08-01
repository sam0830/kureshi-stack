using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutInImage : MonoBehaviour {

	/**
	 * ハイスコアオブジェクトの初期位置(移動前の位置)
	 * @type {Vector3}
	 */
	public static readonly Vector3 CUT_IN_IMAGE_INITIAL_POSITION = new Vector3(0f, -750.0f, 0f);

	/**
	 * ハイスコアオブジェクトの移動後の位置
	 * @type {Vector3}
	 */
	public static readonly Vector3 CUT_IN_IMAGE_TARGET_POSITION = new Vector3(0f, 750.0f, 0f);

	private RectTransform rectTransform;

	void Start () {
		rectTransform = GetComponent<RectTransform>();
		rectTransform.localPosition = CUT_IN_IMAGE_INITIAL_POSITION;
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.localPosition = Vector3.MoveTowards(
			rectTransform.localPosition,
			CUT_IN_IMAGE_TARGET_POSITION,
			400f*Time.deltaTime);
	}
}
