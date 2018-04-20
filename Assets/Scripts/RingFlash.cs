using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingFlash : MonoBehaviour
{
	// a particle shows the location of tap.
	// basically follows the position of the last tap.
	private void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) {
			gameObject.SetActive (false);
			Relocate ();
		}
	}

	private void Relocate ()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mousePosition;
		gameObject.SetActive (true);
	}
}