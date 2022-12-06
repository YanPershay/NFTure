namespace NFTure.Core.Entities.Base
{
    internal interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
