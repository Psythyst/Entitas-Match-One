public sealed class InputSystems : Feature {

    public InputSystems(InputContext Input, GameContext Game) {
        Add(new EmitInputSystem(Input));
        Add(new ProcessInputSystem(Input, Game));
    }
}
