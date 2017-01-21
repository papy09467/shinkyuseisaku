using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class K_Stamina : MonoBehaviour {

	float downValue;
	public float k_time;
	float healValue;
	public float sthealTime;

	public Image stGauge;
	public Image stGaugeout;
	InputManager inputManager;

	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
	}

	void Update () {

		downValue = Time.deltaTime / k_time;
		healValue = downValue / sthealTime;

		//スタミナゲージ色変化
		if (stGauge.fillAmount <= 0.3) {
			stGaugeout.color = Color.red;
		} else {
			stGaugeout.color = Color.white;
		}

		if (stGauge.fillAmount == 0) {
			inputManager.K_St_out ();
		}

		if (stGauge.fillAmount == 1) {
			inputManager.K_Heal_st ();
		}

		if (inputManager.k_moved == true) {
			stGauge.fillAmount -= downValue;
		} 

		if (inputManager.k_moved == false) {
			stGauge.fillAmount += healValue;
			inputManager.Heal_st ();
		}

	}


}