//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Psythyst ~ Psythyst.Plugin.PostProcessor.Entitas.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public sealed partial class GameStateContext : Entitas.Context<GameStateEntity> {
    
    public GameStateContext(IAERCFactory Factory) : base(GameStateComponentsLookup.TotalComponents, 0,
            new Entitas.ContextInfo(
                "GameState",
                GameStateComponentsLookup.ComponentNameCollection,
                GameStateComponentsLookup.ComponentTypeCollection
            ),
            (Entity) => Factory.Create(Entity)) {}
}

public sealed partial class GameStateContext {

    public void ExecutePostConstructor() { 
        var PostConstructorCollection = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            Method => System.Attribute.IsDefined(Method, typeof(PostConstructorAttribute))
        );

        foreach (var PostConstructor in PostConstructorCollection)
            PostConstructor.Invoke(this, null);
    }
}