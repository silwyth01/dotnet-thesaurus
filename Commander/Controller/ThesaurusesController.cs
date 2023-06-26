using AutoMapper;
using Contracts.Create;
using Contracts.Read;
using Contracts.Update;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Route("api/Thesauruss")]
    [ApiController]
    public class ThesaurusesController : ControllerBase
    {
        private readonly IGenericRepository<Thesaurus> _repository;
        private readonly IMapper _mapper;

        public ThesaurusesController(IGenericRepository<Thesaurus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ThesaurusReadDto>> GetAllThesauruss()
        {
            var ThesaurusItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ThesaurusReadDto>>(ThesaurusItems));
        }
        [HttpGet("{id}", Name = "GetThesaurusById")]
        public ActionResult<ThesaurusReadDto> GetThesaurusById(int id)
        {
            var ThesaurusItem = _repository.GetById(id);
            if (ThesaurusItem != null)
            {
                return Ok(_mapper.Map<ThesaurusReadDto>(ThesaurusItem));

            }
            return NotFound();
        }

        //POST api/Thesauruss
        [HttpPost]
        public ActionResult<ThesaurusReadDto> CreateThesaurus(ThesaurusCreateDto ThesaurusCreateDTO)
        {
            var ThesaurusModel = _mapper.Map<Thesaurus>(ThesaurusCreateDTO);
            _repository.Create(ThesaurusModel);
            _repository.SaveChanges();

            var ThesaurusReadDto = _mapper.Map<ThesaurusReadDto>(ThesaurusModel);

            return CreatedAtRoute(nameof(GetThesaurusById), new { ThesaurusReadDto.Id }, ThesaurusReadDto);
            // return Ok(ThesaurusReadDto);
        }


        //PUT API/Thesauruss/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateThesaurus(int id, ThesaurusUpdateDto ThesaurusUpdateDTO)
        {
            var ThesaurusModelFromRepo = _repository.GetById(id);
            if (ThesaurusModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(ThesaurusUpdateDTO, ThesaurusModelFromRepo);

            _repository.Update(ThesaurusModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/Thesauruss/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialThesaurusUptdate(int id, JsonPatchDocument<ThesaurusUpdateDto> patchDoc)
        {
            var ThesaurusModelFromRepo = _repository.GetById(id);
            if (ThesaurusModelFromRepo == null)
            {
                return NotFound();
            }
            var ThesaurusToPatch = _mapper.Map<ThesaurusUpdateDto>(ThesaurusModelFromRepo);
            patchDoc.ApplyTo(ThesaurusToPatch, ModelState);

            if (!TryValidateModel(ThesaurusToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(ThesaurusToPatch, ThesaurusModelFromRepo);

            _repository.Update(ThesaurusModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/Thesauruss/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteThesaurus(int id)
        {
            var ThesaurusModelFromRepo = _repository.GetById(id);
            if (ThesaurusModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(ThesaurusModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
