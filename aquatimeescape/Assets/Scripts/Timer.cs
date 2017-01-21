using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	GameObject overText;
	public float countTime;
	// Use this for initialization
	void Start () {
		overText = GameObject.Find ("Timeup");
		overText.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if(countTime > 0){
			countTime -= Time.deltaTime; //スタートしてからの秒数を格納
			GetComponent<Text>().text = countTime.ToString("F2"); //小数2桁にして表示
		}

		if (countTime <= 0) {
			overText.SetActive (true);
			Invoke ("SceneMove", 3f);
		}
	}

	void SceneMove(){
		CallScript.Scene("title");
		Destroy (gameObject);
	}
}