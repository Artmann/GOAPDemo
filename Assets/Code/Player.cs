using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
	public float speed = 5f;
	public float rotationSpeed = 3f;
	public float cooldown = .4f;
	public GameObject bulletPrefab;

	private bool canShoot;
	
	private CharacterController characterController;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		canShoot = true;
		
		characterController = GetComponent<CharacterController> ();
	}
	
	void Update () {
		var movement = transform.TransformDirection(
			new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"))
		);
		characterController.Move(movement  * speed * Time.deltaTime);
		
		var rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
		transform.Rotate(new Vector3(0, rotation, 0));

		if (Input.GetMouseButton(0) && canShoot) {
			var position = transform.position + transform.forward * 1f;
			var go = Instantiate(bulletPrefab, position, Quaternion.LookRotation(transform.forward));
			StartCoroutine(ShootCooldown());
		}
	}

	IEnumerator ShootCooldown() {
		canShoot = false;
		yield return new WaitForSeconds(cooldown);
		canShoot = true;
	}
}
