using NFTure.Core.Entities.Base;

namespace NFTure.Core.Entities
{
    public class ActivityType : IEnumModel<ActivityType, UserActivityType>
    {
        public UserActivityType Id { get; set; }
        public string Name { get; set; }
    }
}
