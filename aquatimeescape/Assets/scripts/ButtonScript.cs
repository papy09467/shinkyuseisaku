using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public void MultiPlayerBtn(){
		//CallScript.Scene("");
	}
	public void TrainingBtn(){
		CallScript.Scene("training_wait");
	}
	public void OptionBtn(){
		//CallScript.Scene ("");
	}
	public void KumanomiBtn(){
		//CallScript.Scene("");
	}
	public void SharkBtn(){
		CallScript.Scene ("LoadScene");
	}
}
