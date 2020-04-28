using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Game : MonoBehaviour
{
	public AudioSource myMusic;
	public bool startMusic;

	public notes notes;
	public note myNote;
	public static Game game;

	public float delay;

	public int score;
	public int combo;

    // Start is called before the first frame update
    void Start()
    {
		game = this;

		score = 0;
		combo = 0;

		StreamReader reader = new StreamReader("Assets/A_Rainy_Morning.txt");
		createNotes(reader.ReadToEnd());
	}

    // Update is called once per frame
    void Update()
    {
        if (!startMusic)
		{
			if (Input.anyKeyDown)
			{
				startMusic = true;
				notes.startMusic = true;
				myMusic.Play();
			}
		}
    }

	public void hit()
	{
		combo++;
	}

	public void miss()
	{
		combo = 0;
	}

	void createNotes(string notesScript)
	{
		string[] notesInfo = notesScript.Split('\n');

		foreach (string noteInfo in notesInfo)
		{
			float time = float.Parse(noteInfo.Split(' ')[0]);
			int buttonIndex = int.Parse(noteInfo.Split(' ')[1]);
			float x = buttonIndex - 3.5f;
			float z = time * notes.speed + delay;

			note newNote = Instantiate<note>(myNote);
			newNote.transform.position = new Vector3(x, 0.6f, z);
			newNote.transform.parent = notes.transform;
		}
	}

	float getX(string button)
	{
		float x;

		if (button[0] == 's')
		{
			x = -2.5f;
		}
		else if (button[0] == 'd')
		{
			x = -1.5f;
		}
		else if (button[0] == 'f')
		{
			x = -0.5f;
		}
		else if (button[0] == 'j')
		{
			x = 0.5f;
		}
		else if (button[0] == 'k')
		{
			x = 1.5f;
		}
		else
		{
			x = 2.5f;
		}
		return x;
	}
}
