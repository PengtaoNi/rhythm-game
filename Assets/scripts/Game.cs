using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public AudioSource music1;
	public AudioSource music2;
	AudioSource myMusic;
	public bool startMusic;
	public bool musicEnd;
	public bool loadedNotes;

	public int musicIdx;
	public string scriptPath;
	public notes notes;
	public note myNote;
	public static Game game;

	public float delay;
	public float speed;

	public int score;
	public int combo;
	public Text scoreText;
	public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
		game = this;

		loadedNotes = false;
		scriptPath = "Assets/beatmaps/A_Rainy_Morning.txt";

		score = 0;
		combo = 0;
	}

    // Update is called once per frame
    void Update()
    {
		if (!loadedNotes && SceneManager.GetActiveScene().name == "game")
		{
			musicIdx = PlayerPrefs.GetInt("musicIdx");
			scriptPath = PlayerPrefs.GetString("scriptPath");
			if (musicIdx == 1)
			{
				myMusic = music1;
			}
			else
			{
				myMusic = music2;
			}
			StreamReader reader = new StreamReader(scriptPath);
			createNotes(reader.ReadToEnd());
			loadedNotes = true;
		}

        if (!startMusic)
		{
			if (SceneManager.GetActiveScene().name == "game" && Input.GetKeyDown(KeyCode.Return))
			{
				startMusic = true;
				notes.startMusic = true;
				myMusic.Play();
			}
		}

		if (!myMusic.isPlaying)
		{
			musicEnd = true;
		}
    }

	public void hit()
	{
		combo++;
		if (combo >= 5)
		{
			comboText.color = new Color(0, 0, 0, 255);
			comboText.text = "Combo: " + combo;
		}

		score += (combo - combo % 10) / 10 + 1;
		scoreText.text = "Score: " + score;
	}

	public void miss()
	{
		combo = 0;
		comboText.color = new Color(0, 0, 0, 0);
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

			if (noteInfo.Split(' ').Length > 2)
			{
				float length = float.Parse(noteInfo.Split(' ')[2]);
				newNote.transform.localScale = new Vector3(1, 0.2f, length*notes.speed);
				newNote.transform.position = newNote.transform.position + new Vector3(0, 0, (length*notes.speed-1) / 2);
			}
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