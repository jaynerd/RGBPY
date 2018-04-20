using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
	private MainCam mainCamera;
	private FXManager fxManager;

	private void Start ()
	{
		mainCamera = MainCam.Instance;
		fxManager = FXManager.instance;
	}

	private void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals (gameObject.tag)) {
			col.gameObject.SetActive (false);
			//fxManager.pop(col.transform.position, gameObject.tag);
			//mainCamera.StartShake();
		}
	}
}