/********************
ＵＩ画面の動きとＢＧＭ
長谷川弘明

1/19更新
*********************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用
using System.Collections.Generic;

public class Menu : MonoBehaviour {
	Button[] menu_b = new Button[3];
//	Button[] menu_w = new Button[2];
	public List<AudioClip> audioClip = new List<AudioClip>();

	AudioSource audioSource; 

	void Start () {
		// ボタンコンポーネントの取得（タイトル用）
		menu_b[0] = GameObject.Find ("/Canvas/Button1").GetComponent<Button> ();
		menu_b[1] = GameObject.Find ("/Canvas/Button2").GetComponent<Button> ();
		menu_b[2] = GameObject.Find ("/Canvas/Button3").GetComponent<Button> ();

//		// ボタンコンポーネントの取得（選択ＵＩ）
//		menu_w[0] = GameObject.Find ("/Canvas/Button4").GetComponent<Button> ();
//		menu_w[1] = GameObject.Find ("/Canvas/Button5").GetComponent<Button> ();

		// 最初に選択状態にしたいボタンの設定
		menu_b[0].Select();
//		menu_w [0].Select ();

		audioSource = gameObject.AddComponent<AudioSource>();
	}

	void Update () {
		int i = 0;
		Vector3 Menu_dir = new Vector3 (Input.GetAxisRaw ("1pHorizontal"), Input.GetAxisRaw ("1pVertical"), 0);	//コントローラーの入力取得

		//タイトル画面のセレクト処理
		if (Menu_dir.y == 1) {
			if (i == 0) {
				i = 2;
				menu_b[i].Select();
			} else {
				i--;
				menu_b[i].Select();
			}
		}else if(Menu_dir.y == -1){
			if (i == 2) {
				i = 0;
				menu_b[i].Select();
			} else {
				i++;
				menu_b[i].Select();
			}
		}

//		//待機画面のセレクト処理
//		if (Menu_dir.x == 1) {
//			i = 0;
//			menu_w [i].Select();
//		} else if (Menu_dir.x == -1) {
//			i = 1;
//			menu_w [i].Select();
//		}

		if (Input.GetButtonDown ("1pAccel")) {
			audioSource.PlayOneShot (audioClip [0]);
		}
			
	}
}