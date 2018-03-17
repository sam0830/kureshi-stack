using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using Common;

/**
 * ゲームの流れを管理するクラス
 * 1. 3Dモデルが画面の一定位置に出現
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
		CAMERAMOVE,
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
	private GameObject popupObject;
	/**
	 * 経過時間
	 * @type {float}
	 */
	private float userTime = USER_TIME;

	/**
	 * 待ち時間
	 * @type {float}
	 */
	private float waitTime = 0;

	/**
	 * モデルの初期状態の角度
	 * @type {float}
	 */
	private float initialAngleZ = 0;

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
	 * カメラ位置に既にオブジェクトがあるかどうか
	 * @type {bool}
	 */
	private bool _isExistKureshi = false;

	/**
	 * 現在のスコア保存
	 * @type {int}
	 */
	private int _score = 0;

	 /**
	  * ハイスコア更新かどうか
	  * @type {bool}
	  */
	private bool _isHighScoreUpdated = false;

	/**
	 * ゲーム開始時のハイスコア
	 * @type {int}
	 */
	private int _currentHighScore;

	[SerializeField]
	private Canvas gameoverCanvas;

	[SerializeField]
	private GameObject mainCamera;

	[SerializeField]
	private List<GameObject> _kureshiList;

	private Vector3 cameraTargetPos = new Vector3(0f, 0f, 0f);
	private Vector3 kureshiTargetPos = Constant.KURESHI_WAIT_POSITION;
	private Vector3 kureshiInitialPos = Constant.KURESHI_INITIAL_POSITION;

	public float UserTime {
		get { return userTime; }
		set { userTime = value; }
	}

	public int Score {
		get { return _score; }
		set { _score = value; }
	}

	public bool IsExistKureshi {
		get { return _isExistKureshi; }
		set { _isExistKureshi = value; }
	}

	public PhaseType ePhaseType {
		get { return _ePhaseType; }
	}

	public bool IsHighScoreUpdated {
		get { return _isHighScoreUpdated; }
	}

	public int CurrentHighScore {
		get { return _currentHighScore; }
	}

	private void Start() {
		if(gameoverCanvas == null) {
			// TODO: Resources.OnLoad
		}
		if(mainCamera == null) {
			mainCamera = GameObject.Find("Main Camera");
		}
		//Time.timeScale = 1.0f; // 前回ゲームオーバーの場合時間が止まっている
		gameoverCanvas.GetComponent<Canvas>().worldCamera = mainCamera.GetComponent<Camera>();
		_currentHighScore = PlayerPrefs.GetInt(Constant.HIGH_SCORE_KEY, 0);
	}

	private void Update() {
		switch(_ePhaseType) {
			case PhaseType.INITIAL:
				InitialProcess();
				break;
			case PhaseType.CAMERAMOVE:
				CameraMoveProcess();
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

	/**
	 * 呉氏のオブジェクトを初期位置に生成するメソッド
	 * 場合によってよってはカメラの位置移動処理へ遷移
	 */
	private void InitialProcess() {
		if(_isExistKureshi) {
			cameraTargetPos = mainCamera.transform.position + Constant.CAMERA_MOVE_HEIGHT;
			kureshiTargetPos = kureshiTargetPos + Vector3.up;
			kureshiInitialPos = kureshiInitialPos + Vector3.up;
			popupObject = Instantiate(_kureshiList[Random.Range(0, _kureshiList.Count)],
			kureshiInitialPos,
			Quaternion.identity);
			initialAngleZ = popupObject.transform.rotation.z;
			_ePhaseType = PhaseType.CAMERAMOVE;
			return;
		}
		popupObject = Instantiate(_kureshiList[Random.Range(0, _kureshiList.Count)],
		kureshiInitialPos,
		Quaternion.identity);
		initialAngleZ = popupObject.transform.rotation.z;
		_ePhaseType = PhaseType.SETPOSITION;
	}

	/**
	 * カメラ移動中に毎フレーム呼ばれるメソッド
	 */
	 private void CameraMoveProcess() {
 		mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, cameraTargetPos, Time.deltaTime);
 		if(mainCamera.transform.position == cameraTargetPos) {
 			_ePhaseType = PhaseType.SETPOSITION;
 		}
 	}

	private void SetPositionProcess() {
		// 呉氏の初期位置への移動
		popupObject.transform.position = Vector3.MoveTowards(popupObject.transform.position, kureshiTargetPos, Time.deltaTime*4.0f);
		if(popupObject.transform.position == kureshiTargetPos) {
			AudioManager.Instance.PlaySE(Constant.SET_POSITION_SE);
			_ePhaseType = PhaseType.USER;
		}
	}

	private void UserProcess() {
		userTime -= Time.deltaTime;
		if(userTime <= 0) {
			userTime = USER_TIME;
			popupObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			popupObject.GetComponent<TransformGesture>().Type = TransformGesture.TransformType.None;
			popupObject.GetComponent<PolygonCollider2D>().isTrigger = false;
			_ePhaseType = PhaseType.WAIT;
		}
		return;
	}

	/**
	 * ユーザ操作終了後の待ち時間
	 */
	private void WaitProcess() {
		waitTime += Time.deltaTime;
		if(waitTime >= WAIT_TIME) {
			waitTime = 0;
			_ePhaseType = PhaseType.END;
		}
		return;
	}

	private void EndProcess() {
		initialAngleZ = 0;
		_score++;
		popupObject.tag = Constant.STACKED_TAG_NAME;
		_isExistKureshi = false;
		_ePhaseType = PhaseType.INITIAL;
	}

	private void GameOverProcess() {
		// ゲームオーバー画面で毎フレーム呼ばれる
	}

	public void SetGameOver() {
		Debug.Log("ゲームオーバー");
		// ハイスコア更新している場合
		if(_score > PlayerPrefs.GetInt (Constant.HIGH_SCORE_KEY, 0)) {
			PlayerPrefs.SetInt(Constant.HIGH_SCORE_KEY, _score);
			_isHighScoreUpdated = true;
		}
		/**
		 * ゲームオーバービューを表示
		 */
		// Time.timeScale = 0;
		Instantiate(gameoverCanvas);
		_ePhaseType = PhaseType.GAMEOVER;
	}

	public void RoatateModel(float angle) {
		if(_ePhaseType != PhaseType.USER) {
			return;
		}
		popupObject.transform.rotation = Quaternion.Euler(0, 0, initialAngleZ + angle);
	}

}
