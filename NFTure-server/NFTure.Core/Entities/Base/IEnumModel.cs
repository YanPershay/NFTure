namespace NFTure.Core.Entities.Base
{
    public interface IEnumModel<TModel, TModelIdType>
    {
        TModelIdType Id { get; set; }
        string Name { get; set; }
    }
}
