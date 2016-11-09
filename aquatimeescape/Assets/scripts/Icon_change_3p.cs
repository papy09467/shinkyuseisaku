using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon_change_3p : MonoBehaviour {
	InputManager inputManager;
	Image MainImage;

	public Sprite DefaultSprite;
	public Sprite PoisonSprite;
	public Sprite DeathSprite;


	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
		//このobjectのImageを取得
		MainImage = gameObject.GetComponent<Image> ();
	}

	//何かしらのタイミングで呼ばれる
	//通常の状態
	void ChangeStateToDefault() {
		MainImage.sprite = DefaultSprite;
	}

	//毒状態
	void ChangeStateToPoison() {
		MainImage.sprite = PoisonSprite;
	}

	//死状態
	void ChangeStateToDeath() {
		MainImage.sprite = DeathSprite;
	}

	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			ChangeStateToDefault ();
		}

		if (Input.GetKey (KeyCode.W)) {
			ChangeStateToPoison ();
		}

		if (Input.GetKey (KeyCode.E)) {
			ChangeStateToDeath ();
		}
	}
}
