//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Psythyst ~ Psythyst.Plugin.PostProcessor.Entitas.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public class UnSafeAERCFactory : IAERCFactory
{
    public Entitas.IAERC Create(Entitas.IEntity Entity) => new Entitas.UnsafeAERC();
}
