using UnityEngine;
using System.Collections;

public class Kumanomi : MonoBehaviour {

	public GameObject deathEff; //クマノミ死エフェクト

	//CharacterController _controller;
	void Start () {
					
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "shakn") {
			Instantiate (deathEff, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}



