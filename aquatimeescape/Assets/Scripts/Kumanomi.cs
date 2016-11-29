using UnityEngine;
using System.Collections;

public class Kumanomi : MonoBehaviour {

	public GameObject deathEff; //クマノミ死エフェクト
	private float timer;		//クマノミが消えるまでの時間を格納
	private bool death = false; //クマノミがサメにあたったか判定

	//CharacterController _controller;
	void Start () {
					
	}

	// Update is called once per frame
	void Update () {
		//クマノミ削除処理
		if (death == true && Time.time - timer > 2) {
			Destroy (gameObject);
			death = false;
		}

	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "collider") {
			timer = Time.time;
			Instantiate (deathEff, transform.position, Quaternion.identity);
			death = true;
		}
	}
}



