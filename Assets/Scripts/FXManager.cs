using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
	public static FXManager instance;

	#region Sprays

	public GameObject[] sprays;

	private ParticleSystem[] innerSprays;
	private ParticleSystem[] outerSprays;

	private float sprayDelay = Settings.fxSprayDelay;


	#endregion

	public void Awake ()
	{
		instance = this;
		GetSprays ();
	}

	// getting spray particle components.
	private void GetSprays ()
	{
		innerSprays = new ParticleSystem[sprays.Length];
		outerSprays = new ParticleSystem[sprays.Length];
		for (int i = 0; i < sprays.Length; i++) {
			innerSprays [i] = sprays [i].transform.GetChild (0).GetComponent<ParticleSystem> ();
			outerSprays [i] = sprays [i].transform.GetChild (1).GetComponent<ParticleSystem> ();
		}
	}

	// emit & reset right color of the spray based on the selected square's tag.
	public void EmitSpray (string squareTag)
	{
		switch (squareTag) {
		case "Red":
			StopCoroutine ("cStopRedSpray");
			sprays [0].SetActive (false);
			sprays [0].SetActive (true);
			var innerMainA = innerSprays [0].main;
			var outerMainA = outerSprays [0].main;
			innerMainA.loop = true;
			outerMainA.loop = true;
			break;
		case "Green":
			StopCoroutine ("cStopGreenSpray");
			sprays [1].SetActive (false);
			sprays [1].SetActive (true);
			var innerMainB = innerSprays [1].main;
			var outerMainB = outerSprays [1].main;
			innerMainB.loop = true;
			outerMainB.loop = true;
			break;
		case "Blue":
			StopCoroutine ("cStopBlueSpray");
			sprays [2].SetActive (false);
			sprays [2].SetActive (true);
			var innerMainC = innerSprays [2].main;
			var outerMainC = outerSprays [2].main;
			innerMainC.loop = true;
			outerMainC.loop = true;
			break;
		case "Purple":
			StopCoroutine ("cStopPurpleSpray");
			sprays [3].SetActive (false);
			sprays [3].SetActive (true);
			var innerMainD = innerSprays [3].main;
			var outerMainD = outerSprays [3].main;
			innerMainD.loop = true;
			outerMainD.loop = true;
			break;
		case "Yellow":
			StopCoroutine ("cStopYellowSpray");
			sprays [4].SetActive (false);
			sprays [4].SetActive (true);
			var innerMainE = innerSprays [4].main;
			var outerMainE = outerSprays [4].main;
			innerMainE.loop = true;
			outerMainE.loop = true;
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
		yield return new WaitForSeconds (sprayDelay * 0.5f);
		var innerMainA = innerSprays [0].main;
		var outerMainA = outerSprays [0].main;
		innerMainA.loop = false;
		outerMainA.loop = false;
		yield return new WaitForSeconds (sprayDelay);
		sprays [0].SetActive (false);
	}

	public IEnumerator cStopGreenSpray ()
	{
		yield return new WaitForSeconds (sprayDelay * 0.5f);
		var innerMainB = innerSprays [1].main;
		var outerMainB = outerSprays [1].main;
		innerMainB.loop = false;
		outerMainB.loop = false;
		yield return new WaitForSeconds (sprayDelay);
		sprays [1].SetActive (false);
	}

	public IEnumerator cStopBlueSpray ()
	{
		yield return new WaitForSeconds (sprayDelay * 0.5f);
		var innerMainC = innerSprays [2].main;
		var outerMainC = outerSprays [2].main;
		innerMainC.loop = false;
		outerMainC.loop = false;
		yield return new WaitForSeconds (sprayDelay);
		sprays [2].SetActive (false);
	}

	public IEnumerator cStopPurpleSpray ()
	{
		yield return new WaitForSeconds (sprayDelay * 0.5f);
		var innerMainD = innerSprays [3].main;
		var outerMainD = outerSprays [3].main;
		innerMainD.loop = false;
		outerMainD.loop = false;
		yield return new WaitForSeconds (sprayDelay);
		sprays [3].SetActive (false);
	}

	public IEnumerator cStopYellowSpray ()
	{
		yield return new WaitForSeconds (sprayDelay * 0.5f);
		var innerMainE = innerSprays [4].main;
		var outerMainE = outerSprays [4].main;
		innerMainE.loop = false;
		outerMainE.loop = false;
		yield return new WaitForSeconds (sprayDelay);
		sprays [4].SetActive (false);
	}

	#endregion
}