﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kumanomi : MonoBehaviour {

	public Text  gameOverText;
	public float rotationSpeed = 1f;		//自身の回転速度
	public float maxAngleX;					//上回転制限
	public float minAngleX;					//下回転制限

	public float movespeed = 1f;		//移動速度
	public float maxspeed;					//最大速度
	public float accel = 0.1f;				//加速度
	public static float defaltspeed = 1f;	//初期速度

	private bool maxaccel = false;			//加速判定
	//private bool esccheck = false;			//ESC判定
	public bool attack = false;				//攻撃判定
	public bool ColliEnter = false;		//当たり判定
	private GameObject DashEffect;			//エフェクト用
	public GameObject child_kumanomi;				//クマノミモデル用
	GameObject winText;
	public GameObject meshObj;
	public GameObject deathEff; //クマノミ死エフェクト

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
		//characterController = GetComponent<CharacterController> ();
		Debug.Log ("Child : " + child_kumanomi.name);
		rb = child_kumanomi.GetComponent<Rigidbody> ();
		inputManager = FindObjectOfType<InputManager> ();
		animator = child_kumanomi.GetComponent<Animator> ();
		DashEffect = GameObject.Find ("Dash_eff");
		DashEffect.SetActive (false);
		winText = GameObject.Find ("Shark_win");
		winText.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		animator.SetFloat ("Speed", movespeed);
		animator.SetBool ("Attacking", attack);
		float angleY = 0;

		//移動 (地形に当たっていない時に)
		if (ColliEnter == false) {
			transform.position += transform.TransformDirection (Vector3.forward) * movespeed;
		}

		//縦回転制限
		float rotateX = (transform.eulerAngles.x  > 180)? transform.eulerAngles.x -360 : transform.eulerAngles.x;
		float angleX = Mathf.Clamp (rotateX + Input.GetAxisRaw ("1pVertical") * rotationSpeed, minAngleX, maxAngleX);
		angleX = (angleX < 0) ? angleX + 360 : angleX;

		angleY = transform.eulerAngles.y + Input.GetAxisRaw ("1pHorizontal");

		//横回転制限
//		float rotateY = transform.eulerAngles.y;
//		if (direction.x > 0) {
//			angleY = rotateY + direction.x * rotationSpeed;
//			Debug.Log ("プラスがきてるよ");
//		} else if (direction.x < 0) {
//			angleY = rotateY - direction.x * rotationSpeed;
//			Debug.Log ("マイナスになってるよ");
//		} else {
//			Debug.Log ("0がきてるよ");
//		}
		//アニメーション設定
		animator.SetFloat("up_down",transform.rotation.x);

		//回転
		//if (direction.x != 0) {
			transform.rotation = Quaternion.Euler (angleX, angleY, 0);
		//}
		//加速
		if (Input.GetButtonDown ("1pAccel") && maxaccel == false && inputManager.k_st_stopper == false && inputManager.k_st_out == false) {
			maxaccel = true;
			inputManager.K_Moved ();
			DashEffect.SetActive (true);
		}

		if (Input.GetButtonUp ("1pAccel") && maxaccel == true) {
			maxaccel = false;
			inputManager.K_MoveFin ();
			DashEffect.SetActive (false);
		}

		if (inputManager.k_st_out == true) {
			maxaccel = false;
		}

		//加速減速処理(maxaccel true or else)
		if (maxaccel == true) {
			if (movespeed < maxspeed) {
				movespeed += accel;
			}
		} else if (defaltspeed < movespeed) {
			movespeed -= accel;
		}
			
	}

	void OnCollisionEnter(Collision collision){
		ColliEnter = true;
		if (collision.gameObject.tag == "Shark") {
			Invoke ("SceneMove", 3f);
			Debug.Log ("サメ衝突");
			Destroy (gameObject);
			//gameOverText.text = "体験版はここまでです。";
			winText.SetActive (true);
			Instantiate (deathEff, transform.position, Quaternion.identity);
			//meshObj.SetActive (false);
		}
	}
	void SceneMove(){
		CallScript.Scene("title");
		Destroy (gameObject);
	}

	//クマノミがあたったとき
//	void OnCollisionEnter(Collision collision){
//		ColliEnter = true;
//	}

	//オブジェクトが離れた時
	void OnCollisionExit(Collision collision) {
		ColliEnter = false;
	}
}



