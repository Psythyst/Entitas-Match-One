using UnityEngine;

using Entitas;

public class GameController : MonoBehaviour {

    public InputContext Input { get; } = new InputContext(new SafeAERCFactory());
    public GameContext Game { get; } = new GameContext(new SafeAERCFactory());
    public GameStateContext GameState { get; } = new GameStateContext(new SafeAERCFactory());

    Systems _Systems;

    private static GameController _Instance = null;
    public static GameController Instance
    {
        get {
            if (_Instance == null)
                _Instance = FindObjectOfType<GameController>();
            return _Instance;
        }
    }

    private void Start () {
        /* Initialize Context(s). */
        Input.ExecutePostConstructor();
        Game.ExecutePostConstructor();
        GameState.ExecutePostConstructor();

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        /* Initialize Context Observer(s). */
        InitializeContextObserver();
#endif

        /* Initialize System(s). */
        _Systems = new MatchOneSystems(Input, Game, GameState);
        _Systems.Initialize();
	}

    private void Update () {
        _Systems.Execute();
        _Systems.Cleanup();
    }

    private void OnDestroy() {
        _Systems.TearDown();
    }


#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)


    private void InitializeContextObserver()
    {
        try
        {
            CreateContextObserver(Input);
            CreateContextObserver(Game);
            CreateContextObserver(GameState);
        }
        catch (System.Exception)
        { }
    }

    public void CreateContextObserver(IContext Context)
    {
        if (UnityEngine.Application.isPlaying)
        {
            var Observer = new Entitas.VisualDebugging.Unity.ContextObserver(Context);
            DontDestroyOnLoad(Observer.gameObject);
        }
    }

#endif
}