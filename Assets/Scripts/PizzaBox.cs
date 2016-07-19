using UnityEngine;
using System.Collections;

public class PizzaBox : MonoBehaviour {

	public float speed = 2f;

	private bool selected = false;
	private Color initialColor;
	private Color endColor;

	void Awake()
	{
		initialColor = GetComponent<Renderer> ().material.color;
		endColor = Color.red;
	}

	public void Selected()
	{
		selected = true;
		StartCoroutine (TurningSelected());
	}

	public bool isSelected()
	{
		return selected;
	}

	public void Deselect()
	{
		selected = false;
	}

	IEnumerator TurningSelected()
	{
		float t = 0f;

		while (t < 1f) {
			t += Time.deltaTime * speed;
			GetComponent<Renderer> ().material.color = Color.Lerp (initialColor, endColor, t);
			yield return null;
		}
	}


}
