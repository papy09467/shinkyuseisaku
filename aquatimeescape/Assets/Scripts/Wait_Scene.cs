/********************
ＵＩ画面の動きとＢＧＭ(待機画面）
長谷川弘明

1/19更新
*********************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用
using System.Collections.Generic;

public class Wait_Scene : MonoBehaviour {
	Button[] menu_w = new Button[2];
	public List<AudioClip> audioClip = new List<AudioClip>();

	AudioSource audioSource; 

	void Start () {
				// ボタンコンポーネントの取得（選択ＵＩ）
				menu_w[0] = GameObject.Find ("Button4").GetComponent<Button> ();
				menu_w[1] = GameObject.Find ("Button5").GetComponent<Button> ();

		// 最初に選択状態にしたいボタンの設定
				menu_w [0].Select();

		audioSource = gameObject.AddComponent<AudioSource>();
	}

	void Update () {
		Vector3 Menu_dir = new Vector3 (Input.GetAxisRaw ("1pHorizontal"), Input.GetAxisRaw ("1pVertical"), 0);	//コントローラーの入力取得


		if (Input.GetButtonDown ("1pAccel")) {
			audioSource.PlayOneShot (audioClip [0]);
		}
	}
}