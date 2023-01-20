using NFTure.Core.Entities.Base;

namespace NFTure.Core.Entities
{
    public class ActivityType : IEnumModel<ActivityType, ClientActivityType>
    {
        public ClientActivityType Id { get; set; }
        public string Name { get; set; }
    }
}
