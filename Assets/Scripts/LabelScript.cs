using UnityEngine;
using System.Collections;

public class LabelScript : MonoBehaviour {
	
	int buttonHeight, buttonWidth;
	public Texture playButton;
	public GUIStyle guiStyle;
	public float location;
	
	void Start()
	{
		buttonHeight = Screen.height / 5;
		buttonWidth = buttonHeight * 2;
	}
	void OnGUI()
	{
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(location * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect, playButton, guiStyle))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			//Application.LoadLevel("Scene1");
		}
	}
}
