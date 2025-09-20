using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static List<GameObject> items = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem(GameObject item) {
		items.Add (item);
	}

	public void RemoveItem(GameObject item) {
		items.Remove (item);
	}

	public bool HasItem(GameObject item) {
		if (items.Contains (item)) {
			return true;
		}
		return false;
	}
}
