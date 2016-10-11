using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//シーン移動やオーディオの再生を行うスクリプト
public class CallScript : MonoBehaviour {

	public static void Scene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
