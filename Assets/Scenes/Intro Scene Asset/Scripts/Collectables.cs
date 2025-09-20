using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Collectables : MonoBehaviour {

	public string dialogText;
	private AudioClip notifyClip;

	private GameObject dialogTextBox;
	private AudioSource audioSource;

	private Inventory inv;

	void Start () {
		//Fetch the AudioSource from the GameObject
		notifyClip = Resources.Load<AudioClip>("Audio/Notify");
		audioSource = GetComponent<AudioSource>();
		dialogTextBox = GameObject.Find ("DialogText");
		inv = new Inventory();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject()) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 4) && hit.collider.tag == "Collectables" && transform.name == hit.collider.name) {

				var colliderName = hit.collider.name;

				// display a text when clicked
				Debug.Log (hit.collider.name + " : " + dialogText);

				// add to inventory!
				inv.AddItem(hit.collider.gameObject);

				(dialogTextBox.GetComponent<Text> ()).text = dialogText;

				if (colliderName == "milk") {
					(dialogTextBox.GetComponent<Text> ()).text = "Gosh! I was thirsty!";
				} else if (colliderName == "snack") {
					(dialogTextBox.GetComponent<Text> ()).text = "My favorite chips";
//					audioSource.PlayOneShot (audioClip);
				} else if (colliderName == "cheese") {
					(dialogTextBox.GetComponent<Text> ()).text = "We eat a lot of canned food even though it's unhealthy.";
//					audioSource.PlayOneShot (audioClip);
				} else if (colliderName == "bean") {
					(dialogTextBox.GetComponent<Text> ()).text = "Beans Beans Beans.";
//					audioSource.PlayOneShot (audioClip);
				} else if (colliderName == "book") {
					(dialogTextBox.GetComponent<Text> ()).text = "Finally, I found this book! I need to get back to my room.";
//					audioSource.PlayOneShot (audioClip);
				}

				audioSource.PlayOneShot (notifyClip);
				Destroy (hit.collider.gameObject, notifyClip.length);

//				hit.collider.gameObject.SetActive (false);
			}
		}
	}
}