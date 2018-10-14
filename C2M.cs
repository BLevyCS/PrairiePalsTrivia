
using UnityEngine;
using System.Collections;

public class C2M : MonoBehaviour {
	
	public bool goButton;
	
	// Use this for initialization
	void Start () {
		goButton = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(goButton){
			GameObject animal;
			animal = GameObject.Find("1Bear");
			animal.transform.LookAt(transform.position);
			animal.transform.position += transform.forward * 5 * Time.deltaTime;
		}
	}
	
	void OnMouseClick(){
		goButton = true;
	}
}
// Click To Move script

// Moves the object towards the mouse position on left mouse click