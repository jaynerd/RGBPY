using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class controls the shaking effect of the main camera.
 **/

public class MainCam : MonoBehaviour
{
	public static MainCam Instance;

	private Vector3 iPos;
	private float frameRate = Settings.coroutineFrameRate;
	private float shakeDuration = Settings.cameraShakeDuration;
	private float shakeMagnitude = Settings.cameraShakeMagnitude;

	private void Awake ()
	{
		Instance = this;
		iPos = transform.localPosition;
	}

	// starting shaking coroutine until duration reaches to zero.
	private IEnumerator cShake ()
	{
		float duration = shakeDuration;
		while (true) {
			yield return new WaitForSeconds (0.5f / frameRate);
			transform.localPosition = iPos + Random.insideUnitSphere * shakeMagnitude;
			duration -= Time.deltaTime;
			if (duration < 0) {
				transform.localPosition = iPos;
				StopCoroutine ("cShake");
			}
		}
	}

	public void Shake ()
	{
		StartCoroutine ("cShake");
	}
}