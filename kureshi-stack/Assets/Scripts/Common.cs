using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common {
	public static class Constant {
		/**
		 * モデルの出現場所
		 */
		public static readonly Vector3 INITIAL_POSITION = new Vector3(0f, 3f, 0f);

		/**
		 * モデルの待機場所
		 * @type {Vector3}
		 */
		public static readonly Vector3 WAIT_POSITION = new Vector3(0f, 1f, 0f);

		/**
		 * カメラの移動する高さ
		 * @type {Vector3}
		 */
		public static readonly Vector3 CAMERA_MOVE_HEIGHT = new Vector3(0f, 1f, 0f);

		public const string STACKED_TAG_NAME = "Stacked";
		public const string UNTAGGED_TAG_NAME = "Untagged";

		/**
		 * ハイスコアのキー
		 * @type {string}
		 */
		public const string HIGH_SCORE_KEY = "high_score";

		/**
		 * SEのキー
		 * @type {string}
		 */
		public const string SET_POSITION_SE = "SetPositionSE";
	}
}
