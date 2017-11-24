using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public float height = 4f;
	public float offset = 4f;

	private Transform camera;

	void Start () {
		camera = Camera.main.transform;
	}
	
	void LateUpdate () {
		var position = transform.position -transform.forward * offset + new Vector3(0, height, 0); 
		camera.position = position;
		camera.LookAt(transform.position + new Vector3(0, 1f, 0));
	}
}
