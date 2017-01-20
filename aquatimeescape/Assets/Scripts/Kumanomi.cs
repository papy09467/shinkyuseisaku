using UnityEngine;
using System.Collections;

public class Kumanomi : MonoBehaviour {

	public float rotationSpeed = 1f;		//自身の回転速度
	public float maxAngleX;					//上回転制限
	public float minAngleX;					//下回転制限

	public static float movespeed = 1f;		//移動速度
	public float maxspeed;					//最大速度
	public float accel = 0.1f;				//加速度
	public static float defaltspeed = 1f;	//初期速度

	//private bool maxaccel = false;			//加速判定
	private GameObject DashEffect;			//エフェクト用

	void Start () {
	}

	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"), 0);

		//縦回転制限
		float rotateX = (transform.eulerAngles.x  > 180)? transform.eulerAngles.x -360 : transform.eulerAngles.x;
		float angleX = Mathf.Clamp (rotateX + direction.y * rotationSpeed, minAngleX, maxAngleX);
		angleX = (angleX < 0) ? angleX + 360 : angleX;

		//横回転制限
		float rotateY = transform.eulerAngles.y;
		float angleY = rotateY + direction.x * rotationSpeed;

		//回転
		transform.rotation = Quaternion.Euler (angleX, angleY, 0);

		transform.position += transform.TransformDirection (Vector3.forward) * movespeed;
	}
}