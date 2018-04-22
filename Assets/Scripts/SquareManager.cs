using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class manages combined behaviour of each square prefabs.
 * Primarily controls a transition between initial and target squares.
 **/

public class SquareManager : MonoBehaviour
{
	public static SquareManager Instance;

	private Square square;
	private Square[] squares;
	private GameObject iSquare;
	private GameObject tSquare;
	private Vector2 iPos;
	private Vector2 tPos;

	private bool isMoving;
	private bool isSelected;

	private float swapSpeed = Settings.squareSwapSpeed;
	private float minDistance = Settings.squareMinDistance;
	private float frameRate = Settings.coroutineFrameRate;

	private void Awake ()
	{
		Instance = this;
		squares = GetComponentsInChildren<Square> ();
		Init ();
	}

	// initialization.
	private void Init ()
	{
		isMoving = false;
		isSelected = false;
		StopCoroutine (Swap ());
	}

	private void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			bool isSquareClicked = CheckMousePosition ();
			if (!isSquareClicked) {
				ClearSelection ();
			}
		}
	}

	// check if any squares are clicked.
	private bool CheckMousePosition ()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (mousePos, Vector2.zero);
		if (hit.collider != null) {
			GameObject obj = hit.collider.gameObject;
			if (obj.layer.Equals (gameObject.layer)) {
				return true;
			}
		}
		return false;
	}

	// clearing the last selection when no squares are chosen,
	// or upon completion of the most recent transition.
	private void ClearSelection ()
	{
		if (isSelected) {
			isSelected = false;
			for (int i = 0; i < squares.Length; i++) {
				squares [i].StopSpray ();
			}
		}
	}

	// set either initial or target square under the given condition.
	public void SelectSquare (Square square)
	{
		if (!isMoving) {
			if (!isSelected) {
				this.square = square;
				iSquare = square.gameObject;
				square.EmitSpray ();
				isSelected = true;
			} else {
				tSquare = square.gameObject;
				if (iSquare.Equals (tSquare)) {
					ClearSelection ();
					return;
				}
				StartCoroutine (Swap ());
			}
		}
	}

	// inter-changing positions of two selected squares.
	private IEnumerator Swap ()
	{
		isMoving = true;

		// setting destinations.
		iPos = iSquare.transform.position;
		tPos = tSquare.transform.position;

		while (true) {
			yield return new WaitForSeconds (1f / frameRate);
			float speed = swapSpeed * Time.deltaTime;

			// lerping between two positions.
			iSquare.transform.position = Vector2.Lerp (iSquare.transform.position, tPos, speed);
			tSquare.transform.position = Vector2.Lerp (tSquare.transform.position, iPos, speed);

			// checking the distance between each of selected squares origin
			// and destination.
			if (Vector2.Distance (iSquare.transform.position, tPos) < minDistance) {
				iSquare.transform.position = tPos;
				tSquare.transform.position = iPos;
				square.StopSprayAfter ();
				Init ();
				break;
			}
		}
	}
}