using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class SetupState : IStateBase
	{
		private StateManager manager;
		private GameObject player;
		private PlayerControl controller;

		//Constructor
		public SetupState (StateManager managerRef)
		{	
			manager = managerRef;

			if (SceneManager.GetActiveScene().name != "Scene0")
			{
				SceneManager.LoadScene ("Scene0"); 
			}
			
			player = GameObject.Find ("Player");
			controller = player.GetComponent<PlayerControl>();
		}

		public void StateUpdate()
		{
			if (Input.GetKeyUp (KeyCode.Space) )
			{
				manager.SwitchState ( new PlayStateScene1_1 (manager) );
			}

			if (!Input.GetButton("Fire1"))
			controller.transform.Rotate (0, controller.setupSpinSpeed * Time.deltaTime, 0);
		}

		public void StateFixedUpdate()
		{

		}

		public void ShowIt()
		{
			Debug.Log ("In SetupState");


			////  GUI   lives /////////////////////////////////////////////
		
			GUI.Box (new Rect (Screen.width - 210, 10, 200, 120), "Player lives"); 	// Main box
			
			GUI.Box (new Rect (Screen.width - 110, 10, 100, 70),					// Show result  of selection
			string.Format ("Lives left: " + manager.gameDataRef.playerLives));



			if (GUI.Button (new Rect (Screen.width - 200, 70, 100, 40), "EasyBitsy"))		// Button
			manager.gameDataRef.SetPlayerLives( 1000 );

			if (GUI.Button (new Rect (Screen.width - 200, 140, 100, 40), "Medium"))		// Button
			manager.gameDataRef.SetPlayerLives( 30 );

			if (GUI.Button (new Rect (Screen.width - 200, 210, 100, 40), "NightMare"))		// Button
			manager.gameDataRef.SetPlayerLives( 4 );

			////////////////////////////////////////////////////////////////

			// Change color
			GUI.Box ( new Rect (10, 10, 200, 280), "Player Color");
			
			
			if ( GUI.Button ( new Rect (25, 50, 80, 40), "Red"))
			controller.PickedColor (controller.red);

			if ( GUI.Button ( new Rect (25, 100, 80, 40), "Blue"))
			controller.PickedColor (controller.blue);

			if ( GUI.Button ( new Rect (25, 150, 80, 40), "Green"))
			controller.PickedColor (controller.green);

			if ( GUI.Button ( new Rect (25, 200, 80, 40), "Yellow"))
			controller.PickedColor (controller.yellow);

			if ( GUI.Button ( new Rect (25, 250, 80, 40), "White"))
			controller.PickedColor (controller.white);	


			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height - 100, 190, 30),
			"hold click to pause rotation");

			//Play Button	
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height - 50, 200, 40),
			"click here or prees P to play") || Input.GetKeyUp (KeyCode.P))
			{
				manager.SwitchState ( new PlayStateScene1_1 (manager));
				// player.transform.rotation = Quaternion.Slerp(player.transform.rotation, originalRotationValue, Time.time);
				player.transform.position = new Vector3 (54, 5.1f, 40);

			}

		}
	}
}
