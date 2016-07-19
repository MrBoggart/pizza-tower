using UnityEngine;
using System.Collections;

public class TouchDetection : MonoBehaviour {

	public Stack stack;

	Camera myCamera;
	Vector3 touchPosWorld;
	TouchPhase touchPhase = TouchPhase.Ended;
	PizzaBox pizzaBox;

	void Awake()
	{
		myCamera = GetComponent<Camera> ();
	}

	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			/*
			Debug.Log ("Por lo menos detectó el touch");
			touchPosWorld = myCamera.ScreenToWorldPoint (Input.GetTouch(0).position);
			Debug.Log (touchPosWorld);
			//Vector2 touchPosWorld2D = new Vector2 (touchPosWorld.x, touchPosWorld.y);
			RaycastHit hitInformation = Physics.Raycast (touchPosWorld, transform.forward);

			if (hitInformation.collider != null) {
				GameObject touchObject = hitInformation.transform.gameObject;

				Debug.Log (touchObject.name);
			}*/

			Ray ray = myCamera.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

				pizzaBox = hit.transform.gameObject.GetComponent<PizzaBox> ();
				if (pizzaBox.isSelected ()) {
					pizzaBox.Deselect ();
					Debug.Log ("Aplicando fuerza");
					stack.InstanceInTopOf (pizzaBox);
				}

			}

		}
	}

}
