using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float forceMultiplier;
	Vector3 startPosition;
	
	Vector2 nullVelocity = new Vector2(0f,0f);
	bool touchedByUser;
	// Use this for initialization
	void Start () {
		touchedByUser = false;
		//StartLocation ();
		//RemoveVelocity ();
	}

	void RemoveVelocity()
	{
		rigidbody2D.velocity = nullVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if(checkTouch(Input.mousePosition))
			{
			}
		}
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) {
			Debug.Log("Touch input");
			if(checkTouch(Input.GetTouch(0).position))
			{
				Debug.Log("Touch detected");
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ScoreUpdater.ResetScore();
			Application.LoadLevel("StartMenu");
		}
	}
	
	bool checkTouch(Vector3 position) {
		bool clickedOnObject = false;
		Vector3 wp = Camera.main.ScreenToWorldPoint (position);
		Vector2 touchPos = new Vector2 (wp.x, wp.y);
		bool hit = Physics2D.OverlapPoint (touchPos);
		if (hit) {
			if(!touchedByUser)
			{
				touchedByUser = true;
				ScoreUpdater.StartCounting();
			}
			Vector3 newVector = transform.position - wp;
	
			newVector.Normalize();

			Vector2 displacement = new Vector2( newVector.x, newVector.y);
			displacement.y = Mathf.Abs(2 * newVector.y);
			displacement.x /= 2;
			float angle = Mathf.Rad2Deg * Mathf.Atan2 (displacement.y, displacement.x);
			if( angle > 135) {
				angle = 135;
			}
			else if( angle < 45) {
				angle = 45;
			}
			angle = angle * Mathf.Deg2Rad;
			displacement.x = Mathf.Cos (angle);
			displacement.y = Mathf.Sin (angle);

			angle = Mathf.Rad2Deg * Mathf.Atan2 (displacement.y, displacement.x);
			displacement.Normalize();
			Vector2.ClampMagnitude( displacement, 1);

			RemoveVelocity();
			transform.rigidbody2D.AddForce(displacement*forceMultiplier,ForceMode2D.Impulse);
			clickedOnObject = true;
		}
		return clickedOnObject;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "BottomCollider" && 
		    touchedByUser == true) {
			GameOver();
			touchedByUser = false;
		}
	}

	void GameOver()
	{
		Debug.Log("GameOver");
		ScoreUpdater.ResetScore ();
		Handheld.Vibrate();
		Handheld.Vibrate();
		Application.LoadLevel("RestartMenu");
	}

}
