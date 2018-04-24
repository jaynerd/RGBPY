using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class controls the creation of object pools for each of the
 * registered prefabs.
 **/

[System.Serializable]
public class Item
{
	// register prefabs with a quantity to be spawned, parent transformation,
	// and the original prefab itself.
	public int quantity;
	public Transform parent;
	public GameObject prefab;
}

public class ObjectPooler : MonoBehaviour
{
	public List<Item> items;

	private void Awake ()
	{
		CreatePools ();	
	}

	// creates pools of prefabs.
	private void CreatePools ()
	{
		for (int i = 0; i < items.Count; i++) {
			Item item = items [i];
			int quantity = item.quantity;
			Transform parent = item.parent;
			GameObject prefab = item.prefab;
			for (int j = 0; j < quantity; j++) {
				CreateItem (parent, prefab);
			}
		}
	}

	// creates a single item in the assigned pool.
	private void CreateItem (Transform parent, GameObject prefab)
	{
		GameObject item = Instantiate<GameObject> (prefab);
		item.transform.parent = parent.transform;
		item.SetActive (false);
	}
}