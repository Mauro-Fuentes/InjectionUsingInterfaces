using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Interfaces; // PlayState está en esta dirección que tiene IStateBase

namespace Assets.Code.States	// Direcc con los estados
{

    public class PlayStateScene1_1 : IStateBase
	{
		private StateManager manager;
		private GameObject player;
		private Quaternion originalRotationValue = new Quaternion (0, 0, 0, 0);

		//constructor
		public PlayStateScene1_1 (StateManager managerRef)
		{	
			manager = managerRef;
		
			if ( SceneManager.GetActiveScene().name != "Scene1")
			{
				SceneManager.LoadScene ("Scene1"); 
			}

			player = GameObject.Find ("Player");
			
			//player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<Rigidbody>().isKinematic = false;

			//CHOOSE CAMERA/////////
			foreach (GameObject camera in manager.gameDataRef.cameras)
			{
				if (camera.name != "LookAt Camera")
					camera.SetActive(false);
				else
					camera.SetActive(true);
			}
			///////////////////////

			player.transform.rotation = Quaternion.Slerp(player.transform.rotation, originalRotationValue, Time.time);
			player.transform.position = new Vector3 (54, -10, 40);

		}

		public void StateUpdate () 
		{
			// if (Input.GetKeyUp (KeyCode.W))			// W = WIN
			// {
			// 	manager.SwitchState (new WonStateScene1 (manager));
			// }

			// if (Input.GetKeyUp (KeyCode.L))			// L = LOSE
			// {
			// 	manager.SwitchState (new LostStateScene1 (manager));
			// }


			// Check for LIVES
			if (manager.gameDataRef.playerLives <= 0 )
			{
				manager.SwitchState (new LostStateScene1 (manager));
				manager.gameDataRef.ResetPlayer();
				player.GetComponent<Rigidbody>().isKinematic = true;
			}
			
			// Check SCORE
			if (manager.gameDataRef.score >= 2)
			{
				manager.SwitchState (new WonStateScene1 (manager));
				player.GetComponent<Rigidbody>().isKinematic = true;
				player.transform.position = new Vector3 (54, 5.1f, 140);
			}
		}

		public void ShowIt()
		{
			Debug.Log ("In PlayStateScene1_1");
			
			/// SCORE
			GUI.Box(new Rect(10,10,100,25), string.Format ("Score: " + manager.gameDataRef.score));

			/// LIVES
			GUI.Box(new Rect(Screen.width - 110,10,100,25), string.Format("Lives left: "+ manager.gameDataRef.playerLives));


			if(GUI.Button(new Rect(Screen.width/2 - 130, 10, 260, 30),
				string.Format("Click here or Press 2 for Level 1, State 2"))
				|| Input.GetKeyUp(KeyCode.Alpha2))
			{
				manager.SwitchState(new PlayStateScene1_2(manager));
			}
		}

		public void StateFixedUpdate()
		{
			
		}
	}
}