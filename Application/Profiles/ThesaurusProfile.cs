using AutoMapper;
using Contracts.Create;
using Contracts.Read;
using Contracts.Update;
using Domain.Models;

namespace Application.Profiles
{
    public class ThesaurusProfile : Profile

    {
        public ThesaurusProfile()
        {

            CreateMap<Thesaurus, ThesaurusReadDto>();
            CreateMap<ThesaurusCreateDto, Thesaurus>();
            CreateMap<ThesaurusUpdateDto, Thesaurus>();
            CreateMap<Thesaurus, ThesaurusUpdateDto>();
        }

    }
}
