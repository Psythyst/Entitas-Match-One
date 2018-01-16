using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class ProcessInputSystem : ReactiveSystem<InputEntity> {

    readonly GameContext _context;

    public ProcessInputSystem(InputContext Input, GameContext Game) : base(Input) {
        _context = Game;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        foreach (var e in _context.GetEntitiesWithPositionValue(new IntVector2(input.x, input.y)).Where(e => e.isInteractive)) {
            e.isDestroyed = true;
        }
    }
}
