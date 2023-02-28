using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 2f;

	
	void LateUpdate()
	{
		//read the input;
		// between -1 to 1;
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		//get the main camera
		Camera camera = Camera.main;
		
		//Camera's forward and right vectors
		Vector3 forward = camera.transform.forward;
		Vector3 right = camera.transform.right;
		
		//We dont care about up and down (Y axis)
		forward.y = 0f;
		right.y = 0f;
		forward.Normalize(); //Modify's the original vector
		right.Normalize();   

		Vector3 desiredMoveDirection = (forward * vertical) + (right * horizontal);
		desiredMoveDirection.Normalize();
		//normalizing the vector will make it move at the same speed in any direction
		//Vector3 moveDir = new Vector3(vertical,0 , horizontal).normalized;
															//returns a new vector
		
		transform.position += desiredMoveDirection * speed * Time.deltaTime;
	}
	
}
