using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour {
	public Text loadingText;
	public Image loadingBar;
	public Text message;

	private bool canSceneChange = false;
	AsyncOperation async;
	// Use this for initialization
	IEnumerator Start () {
		async = Application.LoadLevelAsync ("training_scene");
		//yield return async;
		//Debug.Log ("");
		async.allowSceneActivation = false;

		while (async.progress < 0.9f) {
			Debug.Log (async.progress);
			loadingText.text = (async.progress * 100).ToString ("F0") + "%";
			loadingBar.fillAmount = async.progress;
			yield return new WaitForEndOfFrame ();
		}

		loadingText.text = "100%";
		loadingBar.fillAmount = 1;

		//yield return new WaitForSeconds(1);

		//async.allowSceneActivation = true; 
		canSceneChange = true;
		message.text = "クリックで進む";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			if (canSceneChange) {
				async.allowSceneActivation = true; 
			}
		}
	}
}
