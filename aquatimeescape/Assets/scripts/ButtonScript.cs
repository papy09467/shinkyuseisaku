using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public void MultiPlayerBtn(){
		CallScript.Scene("multi_wait");
	}
	public void TrainingBtn(){
		CallScript.Scene("training_wait");
	}
	public void OptionBtn(){
		//CallScript.Scene ("");
	}
	public void KumanomiBtn(){
		CallScript.Scene("LoadScene");
	}
	public void SharkBtn(){
		CallScript.Scene("LoadScene");
	}
	public void MultiKumanomiBtn(){
		CallScript.Scene ("multi_scene");
	}
	public void MultiSharkBtn(){
		CallScript.Scene ("multi_scene");
	}
}

