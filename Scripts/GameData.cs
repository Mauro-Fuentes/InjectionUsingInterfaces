using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
	private int playerLivesSelected = 2; // the ones on the Intro
	private int SceneBeginningScore;

	[HideInInspector]
	public int playerLives;
	[HideInInspector]
	public int score;

	//cameras
	public List<GameObject> cameras;

	// Textures
	[Space(20)]
	public Texture2D beginStateSplash;
	public Texture2D lostStateSplash;
	public Texture2D wonStateSplash;
	public Texture2D blackCurtain;

	void Start () 
	{
		playerLives = playerLivesSelected;
	}

	public void ResetPlayer()
	{
		playerLives = playerLivesSelected;
		score = SceneBeginningScore;
	}

	public void SetPlayerLives (int livesSelected)
	{
		playerLivesSelected = livesSelected;
		playerLives = livesSelected;
	}

	public void SetScore()
	{
		SceneBeginningScore = score;
	}

	void Update () 
	{
		
	}

}
