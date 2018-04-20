using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
	public static MainCam Instance;

	private void Awake ()
	{
		Instance = this;
	}
}