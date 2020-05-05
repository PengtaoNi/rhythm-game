using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyAndSeaAndPoem : MonoBehaviour
{
	public void playSkyAndSeaAndPoem()
	{
		SceneManager.LoadScene("game");
		PlayerPrefs.SetInt("musicIdx", 2);
		PlayerPrefs.SetString("scriptPath", "Assets/beatmaps/Sky_and_Sea_and_Poem.txt");
	}
}