using Adform_Todo.Common.Helpers;
using AutoMapper;

namespace Adform_ToDo.Tests
{
    /// <summary>
    /// Automapper initiator.
    /// </summary>
    public class MapperInitiator
    {
        protected MapperInitiator()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            Mapper = mappingConfig.CreateMapper();
        }

        public IMapper Mapper { get; }
    }
}
