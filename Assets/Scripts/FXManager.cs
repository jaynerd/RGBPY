using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
	public static FXManager instance;

	public GameObject[] sprays;

	private float sprayDelay = Settings.fxSprayDelay;

	public void Awake ()
	{
		instance = this;
	}

	// emit & reset right color of the spray based on the selected square's tag.
	public void EmitSpray (string squareTag)
	{
		switch (squareTag) {
		case "Red":
			StopCoroutine ("cStopRedSpray");
			sprays [0].SetActive (false);
			sprays [0].SetActive (true);
			break;
		case "Green":
			StopCoroutine ("cStopGreenSpray");
			sprays [1].SetActive (false);
			sprays [1].SetActive (true);
			break;
		case "Blue":
			StopCoroutine ("cStopBlueSpray");
			sprays [2].SetActive (false);
			sprays [2].SetActive (true);
			break;
		case "Purple":
			StopCoroutine ("cStopPurpleSpray");
			sprays [3].SetActive (false);
			sprays [3].SetActive (true);
			break;
		case "Yellow":
			StopCoroutine ("cStopYellowSpray");
			sprays [4].SetActive (false);
			sprays [4].SetActive (true);
			break;
		}
	}

	// initiating stop spray coroutine.
	public void StopSpray (string squareTag)
	{
		switch (squareTag) {
		case "Red":
			StartCoroutine ("cStopRedSpray");
			break;
		case "Green":
			StartCoroutine ("cStopGreenSpray");
			break;
		case "Blue":
			StartCoroutine ("cStopBlueSpray");
			break;
		case "Purple":
			StartCoroutine ("cStopPurpleSpray");
			break;
		case "Yellow":
			StartCoroutine ("cStopYellowSpray");
			break;
		}
	}

	// stop all sprays when selections are cleared.
	public void StopAllSpray ()
	{
		StopAllCoroutines ();
		for (int i = 0; i < sprays.Length; i++) {
			sprays [i].SetActive (false);
		}
	}

	#region StopSprayByColor

	// stop color matching spray emission.
	public IEnumerator cStopRedSpray ()
	{
		yield return new WaitForSeconds (sprayDelay);
		sprays [0].SetActive (false);
	}

	public IEnumerator cStopGreenSpray ()
	{
		yield return new WaitForSeconds (sprayDelay);
		sprays [1].SetActive (false);
	}

	public IEnumerator cStopBlueSpray ()
	{
		yield return new WaitForSeconds (sprayDelay);
		sprays [2].SetActive (false);
	}

	public IEnumerator cStopPurpleSpray ()
	{
		yield return new WaitForSeconds (sprayDelay);
		sprays [3].SetActive (false);
	}

	public IEnumerator cStopYellowSpray ()
	{
		yield return new WaitForSeconds (sprayDelay);
		sprays [4].SetActive (false);
	}

	#endregion
}