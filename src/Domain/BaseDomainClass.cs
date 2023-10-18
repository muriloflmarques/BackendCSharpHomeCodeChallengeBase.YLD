using GamingApi.Common.Exceptions;

namespace GamingApi.Domain
{
    public class BaseDomainClass
    {
        public BaseDomainClass(ulong id) =>
            this.Id = id;

        private ulong _id;

        public ulong Id
        {
            get => _id;
            init
            {
                if (value == 0)
                    throw new DomainException("Value cannot be zero", nameof(Id));

                _id = value;
            }
        }
    }
}
