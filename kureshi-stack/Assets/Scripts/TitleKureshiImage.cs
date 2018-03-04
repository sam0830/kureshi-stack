using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleKureshiImage : MonoBehaviour {

	private static readonly Vector3 TARGET_POSITION = new Vector3(-10, -613, 0);
	private static readonly Vector3 INITIAL_POSITION = new Vector3(-10, -1300, 0);

	private const float SPRING_CONSTANT = 0.9f;
	private const float ATTENUATION_RATE = 0.1f;

	private Vector3 _acc, _vel, _pos;
	private void Start() {
		_acc = _vel = Vector3.zero;
        _pos = INITIAL_POSITION;
	}

	private void Update() {
		Vector3 diff = TARGET_POSITION - this._pos;
        this._acc = diff * 0.1f;
        this._vel += this._acc;
        this._vel *= 0.9f;
        this._pos += this._vel;
		transform.localPosition = this._pos;
	}
}
