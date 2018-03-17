using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common {
	public static class Constant {
		/**
		 * モデルの出現場所
		 */
		public static readonly Vector3 KURESHI_INITIAL_POSITION = new Vector3(0f, 3f, 0f);

		/**
		 * モデルの待機場所
		 * @type {Vector3}
		 */
		public static readonly Vector3 KURESHI_WAIT_POSITION = new Vector3(0f, 1f, 0f);

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

		/**
		 * ハイスコア文字列
		 * @type {String}
		 */
		public const string PREFIX_STRING = "HighScore\n";

		/**
		 * ハイスコアオブジェクトの初期位置(移動前の位置)
		 * @type {Vector3}
		 */
		public static readonly Vector3 HIGH_SCORE_TEXT_INITIAL_POSITION = new Vector3(0f, 855f, 0f);

		/**
		 * ハイスコアオブジェクトの移動後の位置
		 * @type {Vector3}
		 */
		public static readonly Vector3 HIGH_SCORE_TEXT_TARGET_POSITION = new Vector3(0f, 260f, 0f);

		/**
		 * 戻るボタンの初期位置(移動前の位置)
		 * @type {Vector3}
		 */
		public static readonly Vector3 RESTART_BUTTON_INITIAL_POSITION = new Vector3(0f, -855f, 0f);

		/**
		 * 戻るボタンの移動後の位置
		 * @type {Vector3}
		 */
		public static readonly Vector3 RESTART_BUTTON_TARGET_POSITION = new Vector3(0f, -300f, 0f);
	}
}
