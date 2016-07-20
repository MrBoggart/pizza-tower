using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public Stack stack;
	public Image clock;

	bool restartCounter;
	float timeCounter;
	int level = 0;

	void Awake()
	{
		stack.SelectRandom ();
		StartCoroutine (StartRuningTime());
		//restartCounter = true;
	}

	public void LevelUp()
	{
		level++;
		stack.SelectRandom ();
		StopAllCoroutines ();
		StartCoroutine (StartRuningTime());
		//restartCounter = true;
	}

	void Update()
	{
		/*
		if (restartCounter) {
			restartCounter = false;
			clock.fillAmount = 1f;
			timeCounter = 0f;
		}
		*/
	}
	
	IEnumerator StartRuningTime()
	{
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * (level + 1) * 0.09f;
			clock.fillAmount = 1f - t;
			yield return null;
		}
	}
}
