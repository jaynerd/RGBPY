using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
	private Vector2 iPos;
	private Vector2 tPos;
	private GameObject iSquare;
	private GameObject tSquare;

	private bool isMoving;
	private bool isSelected;

	private float swapSpeed = Settings.squareSwapSpeed;
	private float minDistance = Settings.squareMinDistance;
	private float frameRate = Settings.coroutineFrameRate;

	private FXManager fxManager;

	private void Awake ()
	{
		Init ();
	}

	private void Start ()
	{
		fxManager = FXManager.instance;
	}

	// initialize.
	private void Init ()
	{
		isMoving = false;
		isSelected = false;
		StopCoroutine (Swap ());
	}

	private void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Click ();
		}
	}

	// check if player clicked any squares.
	private void Click ()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (mousePosition, Vector2.zero);
		if (hit.collider != null) {
			GameObject obj = hit.collider.gameObject;
			if (!isMoving && obj.layer.Equals (gameObject.layer)) {
				SelectSquare (obj);
				return;
			}
		}
		ClearSelection ();
	}

	// set either initial or target square under the condition.
	private void SelectSquare (GameObject square)
	{
		if (!isSelected) {
			iSquare = square;
			fxManager.EmitSpray (square.tag);
			isSelected = true;
		} else {
			tSquare = square;
			StartCoroutine (Swap ());
		}
	}

	// clearing all selections.
	private void ClearSelection ()
	{
		if (isSelected) {
			isSelected = false;
			fxManager.StopAllSpray ();
		}
	}

	// swapping positions of two selected squares.
	private IEnumerator Swap ()
	{
		isMoving = true;
		// setting target positions.
		iPos = iSquare.transform.position;
		tPos = tSquare.transform.position;
		while (true) {
			yield return new WaitForSeconds (1f / frameRate);
			float speed = swapSpeed * Time.deltaTime;
			// lerping between two positions.
			iSquare.transform.position = Vector2.Lerp (iSquare.transform.position, tPos, speed);
			tSquare.transform.position = Vector2.Lerp (tSquare.transform.position, iPos, speed);
			// checking distance between each selected squares origin and destination.
			if (Vector2.Distance (iSquare.transform.position, tPos) < minDistance) {
				iSquare.transform.position = tPos;
				tSquare.transform.position = iPos;
				fxManager.StopSpray (iSquare.tag);
				Init ();
				break;
			}
		}
	}
}