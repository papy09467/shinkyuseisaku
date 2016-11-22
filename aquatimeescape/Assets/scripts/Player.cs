/*
サメくん移動プログラム
InputManager Stamina Animator 連携

長谷川弘明
*/
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float rotationSpeed = 1f;
	float maxAngleX = 40;
	float minAngleX = -40;
	public static float movespeed = 1f;
	private bool maxaccel = false;
	public float maxspeed;
	public float accel = 0.1f;
	public static float defaltspeed = 1f;
	private bool esccheck = false;
	public bool attack = false;

	public GameObject deathEff; //クマノミ死エフェクト
	private float timer;		//クマノミが消えるまでの時間を格納
	private bool death = false; //クマノミがサメにあたったか判定


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

		transform.position += transform.TransformDirection (Vector3.forward) * movespeed;

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

		//クマノミ削除処理
		if (death == true && Time.time - timer > 2) {
			Destroy (gameObject);
			death = false;
		}
	}

	//クマノミがサメにあたったときエフェクト起動
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "kumanomi") {
			timer = Time.time;
			Instantiate (deathEff, transform.position, Quaternion.identity);
			death = true;
		}
	}
}
