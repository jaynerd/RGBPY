using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class controls overall behaviour of squares.
 * Should be attached to individual square prefabs.
 **/

public class Square : MonoBehaviour
{
	private SquareManager squareManager;

	#region Spray

	// spray gameobject consisting spray particles.
	private GameObject spray;
	private ParticleSystem[] sprayParticles;

	private float sprayDelay = Settings.squareSprayDelay;

	#endregion

	private void Awake ()
	{
		// getting spray particle components.
		spray = transform.GetChild (0).gameObject;
		sprayParticles = spray.GetComponentsInChildren<ParticleSystem> ();
	}

	private void Start ()
	{
		squareManager = SquareManager.Instance;
	}

	private void OnMouseDown ()
	{
		squareManager.SelectSquare (this);
	}

	// activating the spray gameobject.
	public void EmitSpray ()
	{
		// initializing particle.
		spray.SetActive (false);
		spray.SetActive (true);

		// enabling looping property.
		for (int i = 0; i < sprayParticles.Length; i++) {
			var sprayParticle = sprayParticles [i].main;
			sprayParticle.loop = true;
		}
	}

	// instantly stops & deactivates spray components.
	public void StopSpray ()
	{
		StopCoroutine (StopSprayAfter ());
		spray.SetActive (false);
	}

	// stops spraying after a given delay.
	public IEnumerator StopSprayAfter ()
	{
		yield return new WaitForSeconds (sprayDelay * 0.5f);
		// disabling looping property.
		for (int i = 0; i < sprayParticles.Length; i++) {
			var sprayParticle = sprayParticles [i].main;
			sprayParticle.loop = false;
		}
		yield return new WaitForSeconds (sprayDelay);
		spray.SetActive (false);
	}

	//	private void Start ()
	//	{
	//		//	mainCamera = MainCam.Instance;
	//
	//	}
	//
	//	private void OnCollisionEnter2D (Collision2D col)
	//	{
	//		if (col.gameObject.tag.Equals (gameObject.tag)) {
	//			col.gameObject.SetActive (false);
	//			//fxManager.pop(col.transform.position, gameObject.tag);
	//			//mainCamera.StartShake();
	//		}
	//	}
}