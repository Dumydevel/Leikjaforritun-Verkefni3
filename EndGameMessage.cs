using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMessage : MonoBehaviour
{
	public void RetryPressed()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}