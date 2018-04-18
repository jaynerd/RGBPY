using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonRotator : MonoBehaviour
{
	private Vector3 direction = Vector3.zero;

	private float rotateSpeed = 0f;
	private float rotateAcceleration = 0f;
	private float rotateAccIncrement = 0.005f;
	private float iRotateSpeed = Settings.hexagonRotateSpeed;
	private float iRotateAcceleration = Settings.hexagonRotateAcceleration;

	private void OnEnable ()
	{
		rotateSpeed = iRotateSpeed;
		rotateAcceleration = iRotateAcceleration;
		direction = GetDirection ();
		StartCoroutine (Rotate ());
	}

	private void OnDisable ()
	{
		StopCoroutine (Rotate ());
	}

	private Vector3 GetDirection ()
	{
		Vector3 newDirection = Vector3.zero;
		int r = Random.Range (0, 2);
		if (r.Equals (0)) {
			newDirection = Vector3.forward;
		} else {
			newDirection = Vector3.back;
		}
		return newDirection;
	}

	private IEnumerator Rotate ()
	{
		yield return new WaitForSeconds (2f);
		while (true) {
			yield return new WaitForSeconds (0.05f);
			rotateAcceleration += rotateAccIncrement;
			rotateSpeed *= rotateAcceleration;
			transform.Rotate (direction * rotateSpeed * Time.deltaTime);
			if (rotateSpeed > 5000f) {
				break;
			}
		}
	}
}