using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
	// Start is called before the first frame update
	public Material defaultMaterial;
	public Material pressedMaterial;

	void Start()
	{

	}

	// Update is called once per frame

	void Update()
	{
		string[] buttons = new string[] { "s", "d", "f", "j", "k", "l" };
		foreach (string button in buttons)
		{
			if (Input.GetKeyDown(button))
			{
				this.transform.Find(button).GetComponent<Renderer>().material = pressedMaterial;
			}
			if (Input.GetKeyUp(button))
			{
				this.transform.Find(button).GetComponent<Renderer>().material = defaultMaterial;
			}
		}
	}
}
