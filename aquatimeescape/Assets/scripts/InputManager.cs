﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	Vector2 delta = Vector2.zero;
	bool moved = false;
	float accelsp;

	void Update () {



	}

	public bool Clicked(){
		if(!moved && Input.GetButtonUp("Fire1"))
			return true;
		else
			return false;
	}
		

	public Vector2 GetDeltaPosition(){
		return delta;
	}

	public bool Moved(){		
		return moved;
	}

	public Vector2 GetCursorPosition(){
		return Input.mousePosition;
	}

	public bool GameStart(){
		return true;
	}

}
