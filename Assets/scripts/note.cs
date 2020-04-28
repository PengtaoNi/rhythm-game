using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
	bool onButton;
	string button;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (onButton && Input.GetKeyDown(button))
		{
			gameObject.SetActive(false);

			Game.game.hit();
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

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "button")
		{
			onButton = false;
			button = other.name;

			Game.game.miss();
		}

	}
}
