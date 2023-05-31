using AutoMapper;
using Entities.WEB.DataTransferObjects;
using Entities.WEB.Models;

namespace VocabularyWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WordModel, WordDTO>();
            CreateMap<WordForCreationDto, WordModel>();
            CreateMap<WordForUpdateDto, WordModel>();
        }
    }
}