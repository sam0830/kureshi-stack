using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class CameraMove : MonoBehaviour {

	private void OnTriggerStay2D(Collider2D coll) {
		if(coll.gameObject.tag == Constant.STACKED_TAG_NAME) {
			SequenceManager.Instance.IsExistKureshi = true;
			return;
		}
	}
}
