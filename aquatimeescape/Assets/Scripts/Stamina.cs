using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
	
	float addValue;
	public float time;
	float alpha;

	public Image stGauge; // CircleGauge
	InputManager inputManager;

	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
	}

	void Update () {
					
		if (inputManager.moved == true) {

			addValue = Time.deltaTime / time;
			alpha -= addValue;
			// FillAmount
			stGauge.fillAmount = alpha;
		} 
			
		}

		
}