using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class CameraMove : MonoBehaviour {

	private void Update() {
		RaycastHit2D[] hits = Physics2D.RaycastAll(
		new Vector3(-3.5f, this.transform.position.y -1, 0),
		new Vector3(3.5f, this.transform.position.y -1, 0),
		7.0f);
		foreach(RaycastHit2D hit in hits) {
			if(hit.collider.tag == Constant.STACKED_TAG_NAME) {
				SequenceManager.Instance.IsExistKureshi = true;
				return;
			}
		}
		SequenceManager.Instance.IsExistKureshi = false;
		return;
	}
}
