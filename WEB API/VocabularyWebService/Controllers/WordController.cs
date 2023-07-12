using AutoMapper;
using Contracts.WEB.Interfaces;
using Entities.WEB.DataTransferObjects;
using Entities.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace VocabularyWebAPI.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public WordController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllWords")]
        public IActionResult GetAllWords()
        {
            try
            {
                var owners = _repository.Word.GetAllWords();

                var ownersResult = _mapper.Map<IEnumerable<WordDTO>>(owners);
                return Ok(ownersResult);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{wordName}")]
        public IActionResult GetWordByName(string wordName)
        {
            try
            {
                var owners = _repository.Word.GetWordByName(wordName);
                return Ok(owners);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetWordById(int id)
        {
            try
            {
                var owners = _repository.Word.GetWordById(id);
                return Ok(owners);
            }
            catch (Exception ex )
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutWordItem(int id, [FromBody] WordForUpdateDto word)
        {
            try
            {
                if (word is null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var ownerEntity = _repository.Word.GetWordById(id);
                if (ownerEntity is null)
                {
                    return NotFound();
                }
                _mapper.Map(word, ownerEntity);
                _repository.Word.UpdateWord(ownerEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult PostWordItem([FromBody] WordForCreationDto word) // Post any words(collection).
        {
            try
            {
                if (word is null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var ownerEntity = _mapper.Map<WordModel>(word);
                _repository.Word.AddWord(ownerEntity);
                _repository.Save();
                var createdOwner = _mapper.Map<WordDTO>(ownerEntity);
                return CreatedAtAction(nameof(GetWordById), new { id = createdOwner.WordId }, createdOwner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWordItem(int id)
        {
            try
            {
                var owner = _repository.Word.GetWordById(id);
                if (owner == null)
                {
                    return NotFound();
                }
                _repository.Word.DeleteWord(owner);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}