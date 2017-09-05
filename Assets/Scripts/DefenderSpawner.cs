using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;

	void Start () {
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<Defender>().starCost;
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;
		newDef.transform.parent = parent.transform;
	}
	Vector2 CalculateWorldPointOfMouseClick() {
		Vector2 mousePos = new Vector2();
    	Vector3 worldPos = new Vector3();
    	mousePos = Input.mousePosition;
    	worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    	return worldPos;
	}
}
