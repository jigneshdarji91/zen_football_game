using UnityEngine;
using System.Collections;

public class DisplayScoreGameOver : MonoBehaviour {

	TextMesh textMesh;
	public string scoreName;
	// Use this for initialization
	void Start () {
		Debug.Log (scoreName + PlayerPrefs.GetInt (scoreName));
		guiText.text = "" + PlayerPrefs.GetInt (scoreName);
		//GetComponent (TextMesh).text = PlayerPrefs.GetInt (scoreName);
		//textMesh = (TextMesh) GetComponent(typeof(TextMesh));
		//textMesh.text = "" + PlayerPrefs.GetInt (scoreName);
	}
	
	// Update is called once per frame
	void Update () {
		//guiText = PlayerPrefs.GetInt (scoreName);
	}
}
