public class MatchOneSystems : Feature {

    public MatchOneSystems(InputContext Input, GameContext Game, GameStateContext GameState) {

        // Input
        Add(new InputSystems(Input, Game));

        // Update
        Add(new GameBoardSystems(Game));
        Add(new GameStateSystems(Game, GameState));

        // Render
        Add(new ViewSystems(Game));

        // Destroy
        Add(new DestroySystem(Game));
    }
}
