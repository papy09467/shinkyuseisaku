using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kumanomi : MonoBehaviour {

	public GameObject deathEff; //クマノミ死エフェクト
	public Text  gameOverText;
	public GameObject meshObj;
	public float rotationSpeed = 1f;		//自身の回転速度
	float maxAngleX = 40;					//上回転制限
	float minAngleX = -40;					//下回転制限

	public static float movespeed = 1f;		//移動速度
	public float maxspeed;					//最大速度
	public float accel = 0.1f;				//加速度
	public static float defaltspeed = 1f;	//初期速度

	private bool maxaccel = false;			//加速判定
	//private bool esccheck = false;			//ESC判定
	public bool attack = false;				//攻撃判定
	private bool ColliEnter = false;		//当たり判定
	private GameObject DashEffect;			//エフェクト用


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
		DashEffect = GameObject.Find ("Dash_eff");
		DashEffect.SetActive (false);
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
		transform.rotation = Quaternion.Euler (0, angleY, angleX);

		//加速
		if (Input.GetKeyDown (KeyCode.A) && maxaccel == false) {
			maxaccel = true;
			inputManager.Moved ();
			DashEffect.SetActive (true);
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			maxaccel = false;
			inputManager.MoveFin ();
			DashEffect.SetActive (false);
		}

		//加速減速処理(maxaccel true or else)
		if (maxaccel == true) {
			if (movespeed < maxspeed) {
				movespeed += accel;
			}
		} else if (defaltspeed < movespeed) {
			movespeed -= accel;
		}

		//地形に当たっていない時に移動
		if (ColliEnter == false) {
			transform.position += transform.TransformDirection (Vector3.right) * movespeed;
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "shakn") {
			Invoke ("SceneMove", 3f);
			gameOverText.text = "体験版はここまでです。";
			Instantiate (deathEff, transform.position, Quaternion.identity);
			meshObj.SetActive (false);
			//Destroy (gameObject);
		}
	}
	void SceneMove(){
		CallScript.Scene("title");
		Destroy (gameObject);
	}
}



