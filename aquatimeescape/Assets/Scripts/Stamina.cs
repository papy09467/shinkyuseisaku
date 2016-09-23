using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
	public  float maxStaminaNum;               // スタミナの上限数
	float nowStaminaNum;               // 現在のスタミナ数
	float StaminaDown = 1;

	Slider slider1;

	void Start () {
		slider1 = GameObject.Find ("Slider").GetComponent<Slider>();
		nowStaminaNum = maxStaminaNum;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			nowStaminaNum -= StaminaDown;
		} else if(nowStaminaNum < maxStaminaNum){
			nowStaminaNum += StaminaDown;
		}

		slider1.value = nowStaminaNum;
	}

		
}