using UnityEngine;
using System.Collections;

public class Kumanomi : MonoBehaviour {
	Vector3 patrol = Vector3.zero;	//巡回ポイント設定
	public float radius = 5;
	private float circle_x = 0;
	private float circle_y = 0;

	//CharacterController _controller;
	void Start () {
		//_controller = GetComponent<CharacterController> ();
		Vector3 myTransform = this.transform.position;	//自身の位置を参照
		patrol.x = myTransform.x + radius;					
	}

	// Update is called once per frame
	void Update () {

	}
}



