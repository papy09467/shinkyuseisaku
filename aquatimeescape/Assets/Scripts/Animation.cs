using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {
	Animator _animater;

	// Use this for initialization
	void Start () {
		_animater = GetComponent<Animator> ();	
	
	}

	public void startAnimation(){
		if (_animater) {
			_animater.Play ("ele1");
		}
	}

	public void changeAnimation(){
	//ele1->ele2に切り替え
		_animater.SetBool("isStop",true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
