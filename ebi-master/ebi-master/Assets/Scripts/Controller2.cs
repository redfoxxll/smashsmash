using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Controller2 : MonoBehaviour
{
	[Header("Prefab")]
	public GameObject daggerPrefab;
	GameObject dagger;
	Vector3 diff;
	Vector3 moving;
	public int speed;
	
	void Update()
	{
		if (Input.GetMouseButton(0)) {
			Vector3 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonDown(0)) {
				dagger = (GameObject) Instantiate(daggerPrefab);
				dagger.name = "Dagger";
				dagger.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(100, 100, camera.nearClipPlane));
			} else {
				diff = new Vector3(touch.x - moving.x, touch.y - moving.y, 0);
				Vector3 position = dagger.transform.position;
				position.x += diff.x;
				position.y += diff.y;
				dagger.transform.position = position;
				Vector3 eulerAngles = dagger.transform.eulerAngles;
				eulerAngles.z = Mathf.Atan2(diff.x * -1, diff.y) * Mathf.Rad2Deg;
				if (eulerAngles.z == 90.0f){
					eulerAngles.z = 0;
				}
				dagger.transform.eulerAngles = eulerAngles;
			}
			moving = touch;
		}
		if (Input.GetMouseButtonUp(0)) {
			dagger.rigidbody2D.AddForce(new Vector3(diff.x * speed, diff.y * speed, 0));
			Destroy(dagger, 10.0f);
			dagger = null;
		}
	}
}