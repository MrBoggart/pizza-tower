using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stack : MonoBehaviour {

	public Gameplay GP;
	public GameObject pizzaBoxPrefab;

	List<PizzaBox> stack = new List<PizzaBox>();

	void Awake()
	{
		/*
		foreach (Transform pb in transform) {
			stack.Add (pb.GetComponent<PizzaBox> ());
		}
		*/
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			SelectRandom ();
		}
	}

	public void SelectRandom()
	{
		Transform selected1;
		Transform selected2;

		int selectedIndex1;

		SetAllUnselected ();

		selectedIndex1 = Random.Range (0, transform.childCount - 1);

		selected1 = transform.GetChild(selectedIndex1);
		Debug.Log ("Selected1: " + selected1.GetSiblingIndex());

		selected2 = transform.GetChild(selectedIndex1 + 1);
		Debug.Log ("Selected2: " + selected2.GetSiblingIndex());

		selected1.GetComponent<PizzaBox>().Selected ();
		selected2.GetComponent<PizzaBox>().Selected ();

	}

	public void InstanceInTopOf(PizzaBox pizzaBoxBottom)
	{
		pizzaBoxBottom.transform.Translate (Vector3.up * 0.15f);
		GameObject newBox = Instantiate (pizzaBoxPrefab, pizzaBoxBottom.transform.position, Quaternion.identity) as GameObject;
		newBox.transform.SetParent (transform);

		newBox.GetComponent<Renderer> ().material.color = Color.blue;

		GP.LevelUp ();

		//stack.Clear ();

		//ReGetInstances ();

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
