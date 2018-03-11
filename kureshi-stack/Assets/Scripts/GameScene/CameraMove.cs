using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	void OnTriggerStay2D(Collider2D coll) {
		if(SequenceManager.Instance.ePhaseType == SequenceManager.PhaseType.INITIAL) {
			SequenceManager.Instance.IsExistKureshi = true;
			return;
		}
	}
}
