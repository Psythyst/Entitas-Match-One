public sealed class ViewSystems : Feature {

    public ViewSystems(GameContext Game) {
        Add(new RemoveViewSystem(Game));
        Add(new AddViewSystem(Game));
        Add(new SetViewPositionSystem(Game));
        Add(new AnimatePositionSystem(Game));
    }
}
