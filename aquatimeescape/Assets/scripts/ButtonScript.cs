using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public void MultiPlayerBtn(){
		CallScript.Scene ("multi_wait");
	}
	public void TrainingBtn(){
		CallScript.Scene("training_wait");
	}
	public void OptionBtn(){
		//CallScript.Scene ("");
	}
	public void KumanomiBtn(){
		LoadScript.KumanomiBtn_Load ();
		CallScript.Scene("LoadScene");
	}
	public void SharkBtn(){
		LoadScript.SharkBtn_Load ();
		CallScript.Scene("LoadScene");
	}
	public void MultiKumanomiBtn(){
		LoadScript.KumanomiBtn_Load ();
		CallScript.Scene ("multi_scene");
	}
	public void MultiSharkBtn(){
		LoadScript.SharkBtn_Load ();
		CallScript.Scene ("multi_scene");
	}
		
 }

