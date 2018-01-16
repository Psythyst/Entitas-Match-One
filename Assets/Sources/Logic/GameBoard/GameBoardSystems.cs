public sealed class GameBoardSystems : Feature {

    public GameBoardSystems(GameContext Game) {
        Add(new GameBoardSystem(Game));
        Add(new FallSystem(Game));
        Add(new FillSystem(Game));
    }
}
