using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class WonStateScene1 : IStateBase
	{
		private StateManager manager;

		/////Constructor
		public WonStateScene1 (StateManager managerRef)
		{
			manager = managerRef;

			if ( SceneManager.GetActiveScene().name != "Scene0")
			{
				SceneManager.LoadScene ("Scene0"); 
			}

			manager.gameDataRef.SetScore ();

		}
		////

		public void StateUpdate ()
		{
			// if (Input.GetKeyUp (KeyCode.Space))
			// {
			// 	manager.SwitchState (new PlayStateScene2 (manager));
			// }			
		}

		public void StateFixedUpdate()
		{

		}

		public void ShowIt ()
		{
			Debug.Log ("In WonStateScene1");

			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),
			manager.gameDataRef.wonStateSplash,
			ScaleMode.StretchToFill);

			if (GUI.Button(new Rect(10, 10, 250, 30),
			"Click Here or Space key for next Level") ||
			Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new PlayStateScene2 (manager));
			}
		}	
	}
}
