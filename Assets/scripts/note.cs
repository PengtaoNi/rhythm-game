using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
	public notes notes;
	public Material missNote;
	bool onButton;
	bool pressed;
	string button;

    // Start is called before the first frame update
    void Start()
    {
		pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (onButton && Input.GetKeyDown(button))
		{
			pressed = true;
		}

		if (onButton && Input.GetKey(button))
		{
			if (pressed && gameObject.transform.localScale.z > 1)
			{
				float shrink = notes.speed * Time.deltaTime;
				gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(0, 0, shrink);
				gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, shrink / 2);
			}

			if (pressed && gameObject.transform.localScale.z <= 1)
			{
				gameObject.SetActive(false);
				Game.game.hit();
			}

			if (gameObject.transform.position.z - gameObject.transform.localScale.z / 2 < -1-0.5*notes.speed)
			{
				onButton = false;
			}
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "button")
		{
			onButton = true;
			button = other.name;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "button")
		{
			if (gameObject.transform.position.z - gameObject.transform.localScale.z / 2 < -0.8)
			{
				onButton = false;
				gameObject.GetComponent<Renderer>().material = missNote;

				Game.game.miss();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "button")
		{
			onButton = false;

			gameObject.GetComponent<Renderer>().material = missNote;

			Game.game.miss();
		}

	}
}
