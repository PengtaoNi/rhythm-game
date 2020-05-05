using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aRainyMorning : MonoBehaviour
{
	public void playARainyMorning()
	{
		SceneManager.LoadScene("game");
		PlayerPrefs.SetInt("musicIdx", 1);
		PlayerPrefs.SetString("scriptPath", "Assets/beatmaps/A_Rainy_Morning.txt");
	}
}