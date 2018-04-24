using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class contains specific settings for the core gameplay functions.
 * Any changes should be applied with a caution, since some changes will
 * cause critical issues.
 **/

public class Settings : MonoBehaviour
{
	// the base framerate of all coroutines.
	public static float coroutineFrameRate = 30f;

	#region Camera attributes

	public static float cameraShakeDuration = 0.2f;
	public static float cameraShakeMagnitude = 0.1f;

	#endregion

	#region Hexagon attributes

	public static float hexagonInitialDelay = 2f;
	public static float hexagonRotateSpeed = 40f;
	public static float hexagonMaxRotateSpeed = 5000f;
	public static float hexagonRotateAcceleration = 1f;
	public static float hexagonRotateAccelIncrement = 0.0025f;

	#endregion

	#region Square attributes

	public static float squareSwapSpeed = 20f;
	public static float squareSprayDelay = 1.5f;
	public static float squareMinDistance = 0.05f;

	#endregion
}