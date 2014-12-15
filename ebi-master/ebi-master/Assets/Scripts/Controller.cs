using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	[Header("Prefab")]
	public GameObject carot1Prefab;
	public GameObject carot2Prefab;

	GameObject carot;
	Vector3 diff;
	Vector3 moving;
	public Vector3 startPosition;
	
	void Update()
	{
		if (Input.GetMouseButton(0)) {
			Vector3 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonDown(0)) {
				int rand = Random.Range(0,100);
				if (rand <= 80.0f) {
					carot = (GameObject) Instantiate(carot1Prefab);
					carot.name = "Carot1";
				} else {
					carot = (GameObject) Instantiate(carot2Prefab);
					carot.name = "Carot2";
				}
				carot.transform.position = startPosition;
			} else {
				diff = new Vector3(touch.x - moving.x, touch.y - moving.y, 0);
				Vector3 position = carot.transform.position;
				position.x += diff.x;
				position.y += diff.y;
				carot.transform.position = position;
				Vector3 eulerAngles = carot.transform.eulerAngles;
				eulerAngles.z = Mathf.Atan2(diff.x * -1, diff.y) * Mathf.Rad2Deg;
				carot.transform.eulerAngles = eulerAngles;
			}
			moving = touch;
		}
		if (Input.GetMouseButtonUp(0)) {
			carot.rigidbody2D.AddForce(new Vector3(diff.x * 500, diff.y * 500, 0));
			carot.rigidbody2D.gravityScale = 2;
			Destroy(carot, 1.5f);
			carot = null;
		}
	}
}
