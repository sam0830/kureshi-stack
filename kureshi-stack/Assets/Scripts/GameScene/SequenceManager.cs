using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

/**
 * ゲームの流れを管理するクラス
 * 1. 3Dモデルが画面の一定位置に出現(固定)
 * 2. カウントダウン開始
 * 3. ユーザの入力受付(ドラッグ: 移動, )
 * 4. カウントダウン終了後落下(Rigidbody dynamic)
 * 5. 静止の待ち時間
 * 6. 1に戻る
 * 6.1 ゲームオーバーならゲームオーバーの瞬間の画像を背景に遷移
 * @type {class}
 */
public class SequenceManager : SingletonMonoBehaviour<SequenceManager> {
	public enum PhaseType{
		INITIAL,
		SETPOSITION,
		USER,
		WAIT,
		END,
		GAMEOVER,
	}

	/**
	 * フェース
	 * @type {PhaseType}
	 */
	public PhaseType _ePhaseType =  PhaseType.INITIAL;

	/**
	 * ポップアップしたゲームオブジェクト
	 * @type {GameObject}
	 */
	private GameObject _popupObject;
	/**
	 * 経過時間
	 * @type {float}
	 */
	private float _userTime = USER_TIME;

	/**
	 * 待ち時間
	 * @type {float}
	 */
	private float _waitTime = 0;

	/**
	 * モデルの初期状態の角度
	 * @type {float}
	 */
	private float _initialAngleZ = 0;
	/**
	 * モデルの出現場所
	 */
	private static readonly Vector3 INITIAL_POSITION = new Vector3(0f,3f,0f);

	/**
	 * モデルの待機場所
	 * @type {Vector3}
	 */
	private static readonly Vector3 WAIT_POSITION = new Vector3(0f,1f,0f);

	/**
	 * ユーザが操作可能な時間
	 * @type {float}
	 */
	[SerializeField]
	private const float USER_TIME = 10.0f;
	/**
	 * 静止のための待ち時間
	 * @type {float}
	 */
	[SerializeField]
	private const float WAIT_TIME = 3.0f;

	/**
	 * ハイスコアのキー
	 * @type {string}
	 */
	private const string HIGH_SCORE_KEY = "high_score";

	/**
	 * SEのキー
	 * @type {string}
	 */
	private const string SET_POSITION_SE = "SetPositionSE";

	/**
	 * 現在のスコア保存
	 * @type {int}
	 */
	 private int _score = 0;

	 [SerializeField]
	 private Canvas gameoverCanvas;

	 [SerializeField]
	 private List<GameObject> _kureshiList;

	 private static readonly GameObject PREFAB_GAMEOVER_VIEW;

	public float UserTime {
		get { return _userTime; }
		set { _userTime = value; }
	}

	public int Score {
		get { return _score; }
		set { _score = value; }
	}

	private void Start() {
		if(gameoverCanvas == null) {
			gameoverCanvas = GameObject.Find("GameOverView").GetComponent<Canvas>();
		}
		gameoverCanvas.enabled = false;
		Time.timeScale = 1.0f; // 前回ゲームオーバーの場合時間が止まっている
	}

	private void Update() {
		switch(_ePhaseType) {
			case PhaseType.INITIAL:
				InitialProcess();
				break;
			case PhaseType.SETPOSITION:
				SetPositionProcess();
				break;
			case PhaseType.USER:
				UserProcess();
				break;
			case PhaseType.WAIT:
				WaitProcess();
				break;
			case PhaseType.END:
				EndProcess();
				break;
			case PhaseType.GAMEOVER:
				GameOverProcess();
				break;
			default:
				break;
		}
	}

	private void InitialProcess() {
		_popupObject = Instantiate(_kureshiList[Random.Range(0, _kureshiList.Count)],
		INITIAL_POSITION,
		Quaternion.identity);
		_initialAngleZ = _popupObject.transform.rotation.z;
		_ePhaseType = PhaseType.SETPOSITION;
		return;
	}

	private void SetPositionProcess() {
		_popupObject.transform.position = Vector3.MoveTowards(_popupObject.transform.position, WAIT_POSITION, Time.deltaTime*4.0f);
		if(_popupObject.transform.position == WAIT_POSITION) {
			AudioManager.Instance.PlaySE(SET_POSITION_SE);
			_ePhaseType = PhaseType.USER;
		}
	}

	private void UserProcess() {
		_userTime -= Time.deltaTime;
		if(_userTime <= 0) {
			_userTime = USER_TIME;
			_popupObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			_popupObject.GetComponent<TransformGesture>().Type = TransformGesture.TransformType.None;

			_ePhaseType = PhaseType.WAIT;
		}
		return;
	}

	private void WaitProcess() {
		_waitTime += Time.deltaTime;
		if(_waitTime >= WAIT_TIME) {
			_waitTime = 0;
			_ePhaseType = PhaseType.END;
		}
		return;
	}

	private void EndProcess() {
		_initialAngleZ = 0;
		_ePhaseType = PhaseType.INITIAL;
		_score++;
	}

	private void GameOverProcess() {
		// ゲームオーバー画面で毎フレーム呼ばれる
	}

	public void SetGameOver() {
		Debug.Log("ゲームオーバー");
		if(_score > PlayerPrefs.GetInt (HIGH_SCORE_KEY, 0)) {
			PlayerPrefs.SetInt(HIGH_SCORE_KEY, _score);
			_score = 0;
		}
		Debug.Log("ハイスコア="+PlayerPrefs.GetInt (HIGH_SCORE_KEY, 0));
		/**
		 * ゲームを一時停止する
		 * ゲームオーバービューを表示
		 */
		Time.timeScale = 0;
		gameoverCanvas.enabled = true;
		_ePhaseType = PhaseType.GAMEOVER;
	}

	public void RoatateModel(float angle) {
		if(_ePhaseType != PhaseType.USER) {
			return;
		}
		_popupObject.transform.rotation = Quaternion.Euler(0, 0, _initialAngleZ + angle);
	}

	public int GetHighScore() {
		return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
	}

}
