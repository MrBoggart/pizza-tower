using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stack : MonoBehaviour {

	public GameObject pizzaBoxPrefab;

	List<PizzaBox> stack = new List<PizzaBox>();

	void Awake()
	{
		foreach (Transform pb in transform) {
			stack.Add (pb.GetComponent<PizzaBox> ());
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			SelectRandom ();
		}
	}

	public void SelectRandom()
	{
		PizzaBox selected1;
		PizzaBox selected2;

		int selectedIndex1;

		SetAllUnselected ();

		selectedIndex1 = Random.Range (0, stack.Count - 1);

		selected1 = stack [selectedIndex1];
		Debug.Log (selected1.transform.GetSiblingIndex());

		selected2 = stack[selectedIndex1 + 1];
		Debug.Log (selected2.transform.GetSiblingIndex());

		selected1.Selected ();
		selected2.Selected ();

	}

	public void InstanceInTopOf(PizzaBox pizzaBoxBottom)
	{
		pizzaBoxBottom.transform.Translate (Vector3.up * 0.15f);
		GameObject newBox = Instantiate (pizzaBoxPrefab, pizzaBoxBottom.transform.position, Quaternion.identity) as GameObject;
		newBox.transform.SetParent (transform);

		newBox.GetComponent<Renderer> ().material.color = Color.blue;

		stack.Clear ();

		ReGetInstances ();

	}

	void ReGetInstances()
	{
		foreach (Transform pb in transform) {
			stack.Add (pb.GetComponent<PizzaBox> ());
		}
	}

	void SetAllUnselected()
	{
		foreach (Transform c in transform) {
			c.GetComponent<Renderer> ().material.color = Color.white;
		}
	}

}
