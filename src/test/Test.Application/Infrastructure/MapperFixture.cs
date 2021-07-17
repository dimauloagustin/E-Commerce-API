using Application.Mappings;
using AutoMapper;

namespace Test.Application.Infrastructure
{
    public class MapperFixture
    {
        public IMapper Mapper { get; private set; }

        public MapperFixture()
        {
            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            Mapper = mapperConfig.CreateMapper();
        }
    }
}
