using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour , InputGesture {
	[SerializeField]
	private Vector3 CENTER_OF_GRAVITY = new Vector3(0f,0f,0f);
	private Rigidbody2D rigidboy2D;

	private bool isSelected = false;
	/// <summary>
    ///
    /// </summary>
    private void OnEnable() {
        InputGestureManager.Instance.RegisterGesture (this);
    }

	public void UnregisterGesture() {
		InputGestureManager.Instance.UnregisterGesture (this);
	}

	private void Start() {
		rigidboy2D = GetComponent<Rigidbody2D>();
		rigidboy2D.centerOfMass = CENTER_OF_GRAVITY;
	}

	private void Update() {

	}

	private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere (transform.position + transform.rotation * CENTER_OF_GRAVITY, 0.1f);
    }

	/// <summary>
    /// ジェスチャーの処理順番番号
    /// </summary>
    /// <value>0が一番速い、数値が大きくなると判定順番が遅くなる</value>
    public int Order {
      get { return 9999; }
    }

    /// <summary>
    /// 指定ジェスチャーが処理する必要があるかどうかを取得します
    /// </summary>
    /// <returns>処理する必要があるならtrueを返す</returns>
    /// <param name="info">Info.</param>
    public bool IsGestureProcess( GestureInfo info ) {
        return true;  // 常に処理する(仮)
    }

    /// <summary>
    /// Down時に呼び出されます
    /// </summary>
    /// <param name="info">Info.</param>
    public void OnGestureDown( GestureInfo info ) {
		Ray ray = Camera.main.ScreenPointToRay(info.ScreenPosition);
		Debug.Log(info.ScreenPosition);
        // Rayの当たったオブジェクトの情報を格納する
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 100f);
        // オブジェクトにrayが当たった時
        if(hit.collider) {
			if(hit.collider.gameObject == this.gameObject) {
				isSelected = true;
				return;
			}
		}
		isSelected = false;
    }

    /// <summary>
    /// Up時に呼び出されます
    /// </summary>
    /// <param name="info">Info.</param>
    public void OnGestureUp( GestureInfo info ) {
		isSelected = false;
    }

    /// <summary>
    /// Drag時に呼び出されます
    /// </summary>
    /// <param name="info">Info.</param>
    public void OnGestureDrag( GestureInfo info ) {
		if(!isSelected) {
			return;
		}
		Vector3 pos = this.transform.position;
		float x = Camera.main.ScreenToWorldPoint(info.ScreenPosition).x;
		this.transform.position = new Vector3(x, pos.y, pos.z);
    }

    /// <summary>
    /// Flick時に呼び出されます
    /// </summary>
    /// <param name="info">Info.</param>
    public void OnGestureFlick( GestureInfo info ) {

    }

}
