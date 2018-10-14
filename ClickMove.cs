using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public int smooth;
	private Vector3 targetPosition;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float hitdist = 0.0f;
			if (playerPlane.Raycast(ray, out hitdist)) {
				var targetPoint = ray.GetPoint(hitdist);
				targetPosition = ray.GetPoint(hitdist);
				var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				transform.rotation = targetRotation;
			}
		}
		if(!(transform.position == targetPosition)) {
			transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		}
	}
	
	public void SetTargetPos(Vector3 go)
	{
		targetPosition = go;
	}
}
// Click To Move script

// Moves the object towards the mouse position on left mouse click
