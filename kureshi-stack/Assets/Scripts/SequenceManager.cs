using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ゲームの流れを管理するクラス
 * 1. 3Dモデルが画面の一定位置に出現(固定)
 * 2. カウントダウン開始
 * 3. ユーザの入力受付(ドラッグ: 移動, )
 * 4. カウントダウン終了後落下(Rigidbody dynamic)
 * 5. 静止の待ち時間
 * 6. 1に戻る
 * 6.1 ゲームオーバーならゲームオーバーの瞬間の画像を背景に遷移
 * @type {[type]}
 */
public class SequenceManager : SingletonMonoBehaviour<SequenceManager> {
	public enum PhaseType{
		INITIAL,
		USER,
		WAIT,
		END,
		GAMEOVER
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
	private float _userTime = 0;

	/**
	 * 待ち時間
	 * @type {float}
	 */
	private float _waitTime = 0;
	/**
	 * モデルの出現場所
	 */
	private static readonly Vector3 INITIAL_POSITION = new Vector3(1f,1f,1f);

	/**
	 * ユーザが操作可能な時間
	 * @type {float}
	 */
	[SerializeField]
	private const float USER_TIME = 5.0f;
	/**
	 * 静止のための待ち時間
	 * @type {float}
	 */
	[SerializeField]
	private const float WAIT_TIME = 3.0f;

	[SerializeField]
	private List<GameObject> _kureshiList;

	private void Start() {

	}

	private void Update() {
		switch(_ePhaseType) {
			case PhaseType.INITIAL:
				InitialProcess();
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
		_ePhaseType = PhaseType.USER;
		return;
	}

	private void UserProcess() {
		_userTime += Time.deltaTime;
		if(_userTime >= USER_TIME) {
			_userTime = 0;
			_popupObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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
		_ePhaseType = PhaseType.INITIAL;
	}

	private void GameOverProcess() {
		Debug.Log("ゲームオーバー");
	}

	public void SetGameOver() {
		_ePhaseType = PhaseType.GAMEOVER;
	}

}
