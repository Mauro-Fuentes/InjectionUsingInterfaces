using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Interfaces;	// Aquí está la direcc. de IStateBase

// VER que Assets.Code.States es el directorio en donde está el .cs
// The BeginState file is in the States folder
namespace Assets.Code.States
{
	public class BeginState	: IStateBase	// Este es UN tipo de State y va a implementar IStateBase
	{	
		private StateManager manager;		// referencia a la class StateManager... an object type StateManager
		// manager está para tenér acceso a SwitchState() de StateManager
		
	   	/// Constructor ///////////////////////////////////////
		// cuando cree un Object type BeginState, esto será llamado.
		public BeginState (StateManager managerRef)		// StateManager managerRef ahora tiene cargado this 
		{	
			// igual que StateManager manager, pero ahora es managerRef

			manager = managerRef;
			//Debug.Log("Constructing BeginState");

			if (SceneManager.GetActiveScene().name != "Scene0")
			{
				SceneManager.LoadScene ("Scene0"); 
			}

		}
	   	//////////////////////////////////////////////////////

		// Estos metodos son de la interfaz y los que agregue nuevos
		public void StateUpdate ()		
		{
			// if (Input.GetKeyUp (KeyCode.Space) )
            // {
            //     manager.SwitchState ( new SetupState (manager) );
            // }

		}

        public void ShowIt ()
		{
			Debug.Log ("In BeginState");

			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			// IMAGEN DE INICIO
			/* 
				public static void DrawTexture (Rect position, Texture image, ScaleMode scaleMode);
			*/
			GUI.DrawTexture (new Rect (0 , 0 , Screen.width, Screen.height) , //Rect position
			
			manager.gameDataRef.blackCurtain,	// Texture image. Con dot syntax obtengo la imagen que alojé en GameData Script
			// manager es el nombre ACA de referencia:	private StateManager manager;
			// public GameData gameDataRef;	está dentro de StateManager.
			// beginStateSplash es una referencia publica: public Texture2D beginStateSplash;

			ScaleMode.StretchToFill );	// ScaleMode scaleMode
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			if (GUI.Button (new Rect(Screen.height/2 , Screen.width/2 , 250 , 60) ,
			"Start"))
			{
				manager.SwitchState ( new SetupState (manager) );
			}

		}

		public void StateFixedUpdate ()
		{

		}

		// private void Switch()
        // {
		// 	SceneManager.LoadScene ("PlayScene_1");		//CAMBIARs

		// 	manager.SwitchState(new PlayState(manager));
    	// }

	}
}