//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Psythyst ~ Psythyst.Plugin.PostProcessor.Entitas.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public partial class GameContext {

    public GameEntity positionEntity { get { return GetGroup(GameMatcher.Position).GetSingleEntity(); } }
    public PositionComponent position { get { return positionEntity.position; } }
    public bool hasPosition { get { return positionEntity != null; } }

    public GameEntity SetPosition(IntVector2 newValue) {
        if (hasPosition) {
            throw new Entitas.EntitasException("Could not set Position!\n" + this + " already has an entity with PositionComponent!",
                "You should check if the context already has a positionEntity before setting it or use context.Replace${ComponentName}().");
        }
        var entity = CreateEntity();
        entity.AddPosition(newValue);
        return entity;
    }

    public void ReplacePosition(IntVector2 newValue) {
        var entity = positionEntity;
        if (entity == null) {
            entity = SetPosition(newValue);
        } else {
            entity.ReplacePosition(newValue);
        }
    }

    public void RemovePosition() {
        positionEntity.Destroy();
    }
}

public partial class GameEntity {

    public PositionComponent position { get { return (PositionComponent)GetComponent(GameComponentsLookup.Position); } }
    public bool hasPosition { get { return HasComponent(GameComponentsLookup.Position); } }

    public void AddPosition(IntVector2 newValue) {
        var index = GameComponentsLookup.Position;
        var component = CreateComponent<PositionComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePosition(IntVector2 newValue) {
        var index = GameComponentsLookup.Position;
        var component = CreateComponent<PositionComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePosition() {
        RemoveComponent(GameComponentsLookup.Position);
    }
}

public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPosition;

    public static Entitas.IMatcher<GameEntity> Position {
        get {
            if (_matcherPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Position);
                matcher.componentNames = GameComponentsLookup.ComponentNameCollection;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
