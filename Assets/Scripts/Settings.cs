using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
	public static float coroutineFrameRate = 30f;

	#region Hexagon attributes

	public static float hexagonInitialDelay = 2f;
	public static float hexagonRotateSpeed = 40f;
	public static float hexagonMaxRotateSpeed = 5000f;
	public static float hexagonRotateAcceleration = 1f;
	public static float hexagonRotateAccelIncrement = 0.0025f;

	#endregion

	#region Square attributes

	public static float squareSwapSpeed = 20f;
	public static float squareMinDistance = 0.05f;

	#endregion

	#region Particle attributes

	public static float fxSprayDelay = 1.5f;

	#endregion
}