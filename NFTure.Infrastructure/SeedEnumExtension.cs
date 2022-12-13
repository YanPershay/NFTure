using NFTure.Core.Entities.Base;

namespace NFTure.Infrastructure
{
    internal static class SeedEnumExtension
    {
        public static IEnumerable<TModel> GetValuesFromEnum<TModel, TEnum>() where TModel : IEnumModel<TModel, TEnum>, new()
        {
            var enums = new List<TModel>();

            foreach (var enumVar in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                enums.Add(new TModel
                {
                    Id = enumVar,
                    Name = enumVar.ToString()
                });
            }

            return enums;
        }
    }
}
