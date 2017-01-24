using UnityEngine;
using System.Collections;

public class shark_hit : MonoBehaviour {
	GameObject winText;
	public GameObject meshObj;
	public GameObject deathEff; //クマノミ死エフェクト

	void Start(){
		winText = GameObject.Find ("Shark_win");
		winText.SetActive (false);
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "shakn") {
			Destroy (gameObject);
			Invoke ("SceneMove", 3f);
			//gameOverText.text = "体験版はここまでです。";
			winText.SetActive (true);
			Instantiate (deathEff, transform.position, Quaternion.identity);
			meshObj.SetActive (false);
		}
	}

	void SceneMove(){
		CallScript.Scene("title");
		Destroy (gameObject);
	}
}
