using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
	private float frameRate = Settings.coroutineFrameRate;

	#region Rotation attributes

	private Vector3 rotateDirection = Vector3.zero;

	private float rotateSpeed = Settings.hexagonRotateSpeed;
	private float maxRotateSpeed = Settings.hexagonMaxRotateSpeed;
	private float rotateAcceleration = Settings.hexagonRotateAcceleration;
	private float rotateAccelIncrement = Settings.hexagonRotateAccelIncrement;

	private float initialDelay = Settings.hexagonInitialDelay;
	private float initRotateSpeed = Settings.hexagonRotateSpeed;
	private float initRotateAcceleration = Settings.hexagonRotateAcceleration;

	#endregion

	private void OnEnable ()
	{
		// initializing speed and acceleration.
		rotateSpeed = initRotateSpeed;
		rotateAcceleration = initRotateAcceleration;
		rotateDirection = GetDirection ();
		StartCoroutine (Rotate ());
	}

	private void OnDisable ()
	{
		StopCoroutine (Rotate ());
	}

	// setting the rotate direction on z-axis, right or left.
	private Vector3 GetDirection ()
	{
		int n = Random.Range (0, 2);
		Vector3 direction = Vector3.zero;
		if (n.Equals (0)) {
			direction = Vector3.forward;
		} else {
			direction = Vector3.back;
		}
		return direction;
	}

	// coroutine for rotating the hexagon.
	private IEnumerator Rotate ()
	{
		yield return new WaitForSeconds (initialDelay);
		while (true) {
			yield return new WaitForSeconds (1f / frameRate);
			rotateAcceleration += rotateAccelIncrement;		// accelerate.
			rotateSpeed *= rotateAcceleration;
			transform.Rotate (rotateDirection * rotateSpeed * Time.deltaTime);
			if (rotateSpeed > maxRotateSpeed) {
				break;
			}
		}
	}
}