using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
	
	float downValue;
	public float time;
	float healValue;
	public float sthealTime;

	public Image stGauge; // CircleGauge
	InputManager inputManager;

	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
	}

	void Update () {

		downValue = Time.deltaTime / time;
		healValue = downValue / sthealTime;

		if (stGauge.fillAmount == 0) {
			inputManager.St_out ();
		}

		if (stGauge.fillAmount == 1) {
			inputManager.Heal_st ();
		}

		if (inputManager.moved == true) {
			stGauge.fillAmount -= downValue;
		} 

		if (inputManager.moved == false) {
			stGauge.fillAmount += healValue;
			inputManager.Heal_st ();
		}
			
	}

		
}