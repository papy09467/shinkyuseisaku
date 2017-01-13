using UnityEngine;
using System.Collections;

public class PlayerMake : MonoBehaviour {

	public GameObject kumanomi;
	public GameObject shark;

	// Use this for initialization
	void Start () {
		switch (LoadScript.playerType_p) {
		case LoadScript.playerType.kumanomi:
			{
				Instantiate (kumanomi);
				break;
			}

		case LoadScript.playerType.shark:
			{
				Instantiate (shark);
				break;
			}

		default:
			{
				break;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
