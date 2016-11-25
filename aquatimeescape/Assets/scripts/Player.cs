/*********************************
サメくん移動プログラム
InputManager Stamina Animator 連携

長谷川弘明

更新 11/25 詐欺士
*********************************/
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float rotationSpeed = 1f;		//回転速度
	float maxAngleX = 40;					//上回転制限
	float minAngleX = -40;					//下回転制限

	public static float movespeed = 1f;		//移動速度
	public static float defaltspeed = 1f;	//元の速度
	public float maxspeed;					//最大速度
	public float accel = 0.1f;				//加速度

	private bool maxaccel = false;			//加速判定
	private bool esccheck = false;			//Esc判定
	public bool attack = false;				//攻撃判定
	private bool Enter = false;						//当たり判定

	Rigidbody rb;
	CharacterController characterController;
	InputManager inputManager;
	Animator animator;

	// Use this for initialization
	void Awake () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	void Start () {
		characterController = GetComponent<CharacterController> ();
		rb = GetComponent<Rigidbody> ();
		inputManager = FindObjectOfType<InputManager> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"), 0);
		animator.SetFloat ("Speed", movespeed);
		animator.SetBool ("Attacking", attack);

		//inputManager.GameStart ();
		direction.y = -direction.y;

		//縦回転制限
		float rotateX = (transform.eulerAngles.x  > 180)? transform.eulerAngles.x -360 : transform.eulerAngles.x;
		float angleX = Mathf.Clamp (rotateX + direction.y * rotationSpeed, minAngleX, maxAngleX);
		angleX = (angleX < 0) ? angleX + 360 : angleX;

		//横回転制限
		float rotateY = transform.eulerAngles.y;
		float angleY = rotateY + direction.x * rotationSpeed;

		//アニメーション設定
		animator.SetFloat("up_down",transform.rotation.x);

		//回転
		transform.rotation = Quaternion.Euler (angleX, angleY, 0);

		//加速
		if (Input.GetKeyDown (KeyCode.A) && maxaccel == false) {
			maxaccel = true;
			inputManager.Moved ();
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			maxaccel = false;
			inputManager.MoveFin ();
		}
				
		//加速減速処理(maxaccel true or else)
		if (maxaccel == true) {
			if (movespeed < maxspeed) {
				movespeed += accel;
			}
		} else if (defaltspeed < movespeed) {
			movespeed -= accel;
		}

		//移動
		if (Enter == false) {
			transform.position += transform.TransformDirection (Vector3.forward) * movespeed;
		}

		//マウスカーソル表示
		if (Input.GetKeyDown (KeyCode.Escape) && esccheck == false) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			esccheck = true;
		}
		if (Input.GetKeyDown (KeyCode.Escape) && esccheck == true) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = false;
			esccheck = false;
		}

		//攻撃処理
		if (Input.GetMouseButton(0)) {
			attack = true;
		}
	}

	//サメがオブジェクトに当たった時
	void OnCollisionEnter(Collision collision){
		//if (collision.gameObject.name == "Seabed") {
			Enter = true;
		//}
	}

	//サメがオブジェクトから離れた時
	void OnCollisionExit(Collision collision) {
		Enter = false;
	}
}
