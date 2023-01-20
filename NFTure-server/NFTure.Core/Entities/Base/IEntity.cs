namespace NFTure.Core.Entities.Base
{
    internal interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
