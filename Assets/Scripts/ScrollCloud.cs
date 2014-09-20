using UnityEngine;
using System.Collections;

public class ScrollCloud : MonoBehaviour {

	float scrollSpeed;
	private Vector2 leftEdge;
	private Vector2 rightEdge;
	// Use this for initialization
	void Start () {
		scrollSpeed = 0.01f * Random.Range(-3, 3);
	
		float distance = (transform.position - Camera.main.transform.position).z;

		leftEdge.x = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x 
			- renderer.bounds.size.x * 0.4f;
		leftEdge.y = Random.Range (Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).y,
		                          Camera.main.ViewportToWorldPoint (new Vector3 (0, 1f, distance)).y);

		rightEdge.x = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x 
			+ renderer.bounds.size.x * 0.4f;
		rightEdge.y = leftEdge.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (renderer.isVisible) {
			transform.Translate (Vector2.right * scrollSpeed);
		} 
		else 
		{
			PseudoRespawn();
			if(scrollSpeed > 0)
			{
				transform.position = leftEdge;
			}
			else
			{
				transform.position = rightEdge;
			}

		}
	}

	void PseudoRespawn()
	{
		float distance = (transform.position - Camera.main.transform.position).z;
		leftEdge.y = Random.Range (Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).y,
		                           Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distance)).y);
		rightEdge.y = leftEdge.y;
		while (Mathf.Abs(scrollSpeed) < 0.01f) 
		{
			scrollSpeed = 0.01f * Random.Range (-3, 3);
		}
	}
}
