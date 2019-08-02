using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.States;			// todos los estodos que utilizan IStateBase
using Assets.Code.Interfaces;		//agrego la interfaz IStateBase

public class StateManager : MonoBehaviour
{
	private IStateBase activeState;			// que sea cualquier objeto tipo IStateBase.
	// hasta acá activeState es NULL
	// Más tarde esta variable representará cualquier objeto que cumpla con IStateBase.	

	private static StateManager instanceStateManagerRef; // Singleton

	[HideInInspector] public GameData gameDataRef; // Will be called in Start()

	void Awake()
	{
		//Singleton
		if ( instanceStateManagerRef == null )
		{
			instanceStateManagerRef = this; // o sea, la instancia... ya está... es esta.
			DontDestroyOnLoad (gameObject);	// o sea, no destruyas este gameObject si cambia la escena
		}
		else
		{
			DestroyImmediate (gameObject);
		}
	}


	void Start () 
	{
		activeState = new BeginState (this);	
		// New Object del tipo BeginState-IStateBase
		// al crear un nuevo BeginState Object... el Constructor en BeginState class es llamado:
			
		/* 	public BeginState(StateManager managerRef)	// StateManager managerRef ahora cargado con this
			{
				manager = managerRef;
			}
		*/
		// Esto viaja a BeginState Script con el parámetro StateManager Objeto Componente.

		// y vuelve creado e inicializado.

		gameDataRef = GetComponent<GameData>();
	}


	void Update () 		// StateManager usa el UpDate() de Unity para delegar el control al activeState
	{
		if (activeState != null)
		{
			activeState.StateUpdate ();	//activeState es cualquiera que esté activa...y como
			// todas tiene un StateUpdate porque se ven forzadas por IStateBase, no hay problema.

			//activeState ahora tiene una referencia a BeginState.
		}
	}


	void OnGUI()
	{
		if (activeState != null)
		{
			activeState.ShowIt ();
		}
	}


	public void SwitchState (IStateBase newState)	//paso a SwitchState el nuevo estado que quiero que esté activo.
	{
		activeState = newState;
	}


	public void Restart()
	{
		Destroy (gameObject);

		SceneManager.LoadScene ("Scene0");
	}
	
}
