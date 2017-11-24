using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
	public float maxSpeed = 6f;
	public float acceleration = .1f;

	public float verticalSpeed;
	private float horizontalSpeed;

	private CharacterController characterController;

	void Start () {
		characterController = GetComponent<CharacterController> ();

		verticalSpeed = 0;
		horizontalSpeed = 0;
	}
	
	void Update () {
		verticalSpeed = Mathf.Clamp (
			verticalSpeed + ((Input.GetAxis("Vertical") * acceleration - (acceleration / 2f)) * Time.deltaTime),
			maxSpeed,
			-maxSpeed
		);
		horizontalSpeed = Mathf.Clamp (
			horizontalSpeed + ((Input.GetAxis("Horizontal") * acceleration - (acceleration / 2f)) * Time.deltaTime),
			-maxSpeed,
			maxSpeed
		);

		characterController.Move(new Vector3(horizontalSpeed, 0f, verticalSpeed));
	}
}
