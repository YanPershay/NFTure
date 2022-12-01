namespace Hexagonal.Core.Entities.Base
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        public virtual TId Id { get; protected set; }

        private int? _requestedHashCode;

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Entity<TId>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient() && !_requestedHashCode.HasValue)
            {
                _requestedHashCode = Id.GetHashCode() ^ 27;

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        private bool IsTransient()
        {
            return Id.Equals(default(TId));
        }
    }
}
