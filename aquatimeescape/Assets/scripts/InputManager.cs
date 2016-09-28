using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	Vector2 delta = Vector2.zero;
	public bool moved = false;
	float accelsp;
	public bool st_out = false;
	public bool heal_st = false;

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
		moved = true;
		return moved;
	}

	public bool MoveFin(){
		moved = false;
		return moved;
	}

	public bool St_out() {
		
		if (st_out == false)
			st_out = true;
		else
			st_out = false;
		
		return st_out;
	}

	public bool Heal_st() {

		if (heal_st == false)
			heal_st = true;
		else
			heal_st = false;

		return heal_st;
	}	

	public Vector2 GetCursorPosition(){
		return Input.mousePosition;
	}

	public bool GameStart(){
		return true;
	}
		

}
