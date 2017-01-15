using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Vector3 warp_destination;

	void OnTriggerEnter(Collider other){
		other.gameObject.transform.position = warp_destination;
	}
}
