//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Psythyst ~ Psythyst.Plugin.PostProcessor.Entitas.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public sealed partial class GameStateMatcher 
{
    public static Entitas.IAllOfMatcher<GameStateEntity> AllOf(params int[] Index) => Entitas.Matcher<GameStateEntity>.AllOf(Index);
    public static Entitas.IAnyOfMatcher<GameStateEntity> AnyOf(params int[] Index) => Entitas.Matcher<GameStateEntity>.AnyOf(Index);

    public static Entitas.IAllOfMatcher<GameStateEntity> AllOf(params Entitas.IMatcher<GameStateEntity>[] Matcher) => Entitas.Matcher<GameStateEntity>.AllOf(Matcher);
    public static Entitas.IAnyOfMatcher<GameStateEntity> AnyOf(params Entitas.IMatcher<GameStateEntity>[] Matcher) => Entitas.Matcher<GameStateEntity>.AnyOf(Matcher);
}