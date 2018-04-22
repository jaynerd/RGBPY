using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class emits a ring shaped particle to trackdown
 * the location of the last tap or click.
 **/

public class RingFlash : MonoBehaviour
{
	// check mouse input.
	private void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) {
			gameObject.SetActive (false);
			MoveToPoint ();
		}
	}

	// move the ring flash to the assigned position.
	private void MoveToPoint ()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mousePosition;
		gameObject.SetActive (true);
	}
}