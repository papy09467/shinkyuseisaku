using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	Vector2 delta = Vector2.zero;
	public bool moved = false;
	public bool k_moved = false;
	public bool st_out = false;
	public bool heal_st = false;
	public bool k_st_out = false;
	public bool k_heal_st = false;


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
	//クマノミ用ムーブ
	public bool K_Moved(){		
		k_moved = true;
		return k_moved;
	}

	public bool K_MoveFin(){
		k_moved = false;
		return k_moved;
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
	//クマノミ用
	public bool K_St_out() {

		if (k_st_out == false)
			k_st_out = true;
		else
			k_st_out = false;

		return k_st_out;
	}

	public bool K_Heal_st() {

		if (k_heal_st == false)
			k_heal_st = true;
		else
			k_heal_st = false;

		return k_heal_st;
	}	

	public Vector2 GetCursorPosition(){
		return Input.mousePosition;
	}

	public bool GameStart(){
		return true;
	}
		

}
