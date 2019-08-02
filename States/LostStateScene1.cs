using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class LostStateScene1 : IStateBase
	{
		private StateManager manager;

		/////Constructor
		public LostStateScene1 (StateManager managerRef)
		{	
			manager = managerRef;

			if ( SceneManager.GetActiveScene().name != "Scene0")
			{
				SceneManager.LoadScene ("Scene0"); 
			}
		}
		////

		public void StateUpdate ()
		{
			
			// if (Input.GetKeyUp (KeyCode.Space))
			// {
			// 	SceneManager.LoadScene ("Scene0");		// hay que cambiarlo
			// 	manager.SwitchState (new PlayStateScene1_1 (manager));
			// }


			// if (Input.GetKeyUp (KeyCode.R))				// R = Restart
			// {
			// 	manager.Restart ();
			// }
		}

		public void StateFixedUpdate()
		{

		}

		public void ShowIt ()
		{
			Debug.Log ("In LostStateScene1");


			/// LOST SPLASH
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),
			manager.gameDataRef.lostStateSplash,
			ScaleMode.StretchToFill);
			

			/// REPEAT LEVEL
			if (GUI.Button(new Rect(10, 10, 270, 30),
				"Click Here or Space key to repeat Level") 
				|| Input.GetKeyUp (KeyCode.Space))
			{
				manager.SwitchState (new
				PlayStateScene1_1 (manager));
			}
			

			/// RESTART GAME FROM SCRATCH
			if (GUI.Button(new Rect(10, 50, 270, 30),
				"Click Here or Return key to Restart Game") 
				|| Input.GetKeyUp (KeyCode.Return))
			{
				manager.Restart();
			}

		}		
	}
}
