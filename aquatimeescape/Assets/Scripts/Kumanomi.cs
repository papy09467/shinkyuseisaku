using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kumanomi : MonoBehaviour {

	public GameObject deathEff; //クマノミ死エフェクト
	public Text  gameOverText;
	public GameObject meshObj;

	//CharacterController _controller;
	void Start () {
					
	}

	// Update is called once per frame
	void Update () {

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



