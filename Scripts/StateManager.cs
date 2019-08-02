using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.States;			// every state that uses IStateBase
using Assets.Code.Interfaces;		// interface IStateBase

public class StateManager : MonoBehaviour
{
	private IStateBase activeState;			// any objet of type IStateBase.
	// up to here activeState is NULL
	// in the future, this variable would represet any object that complies with IStateBase.

	private static StateManager instanceStateManagerRef; // Singleton

	[HideInInspector] public GameData gameDataRef; 		// Will be called in Start()

	void Awake()
	{
		//Singleton
		if ( instanceStateManagerRef == null )
		{
			instanceStateManagerRef = this;
			DontDestroyOnLoad (gameObject);		// Don't destroy this in case we change scenes. Not a good practice thou.
		}
		else
		{
			DestroyImmediate (gameObject);
		}
	}


	void Start () 
	{
		activeState = new BeginState (this);	
		// New Object of type BeginState-IStateBase

		// when we create a new BeginState Object... the BeginState constructor is called (check there)
			/* 	public BeginState(StateManager managerRef)	// StateManager managerRef ahora cargado con this
				{
					manager = managerRef;
				}
			*/

		// Thista data travels to BeginState Script with StateManager managerRef parametre.
		// then returns already created and initialised ready to work.

		gameDataRef = GetComponent<GameData>();
	}

	void Update () 		// StateManager uses Unity's UpDate() and relies on activeState (control)
	{
		if (activeState != null)
		{
			activeState.StateUpdate ();	//activeState is any active one
			// The thing is that, as every StateUpdate is bound by IStateBase... it's ok.

			//activeState now has a reference to BeginState.
		}
	}

	void OnGUI()
	{
		if (activeState != null)
		{
			activeState.ShowIt ();
		}
	}

	public void SwitchState (IStateBase newState)	//go to SwitchState, the new state I want active.
	{
		activeState = newState;
	}

	public void Restart()
	{
		Destroy (gameObject);

		SceneManager.LoadScene ("Scene0");
	}
	
}
