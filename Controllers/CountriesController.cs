using BookApi.Dtos;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {

            var countries = _countryRepository.GetCountries();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var countriesDto = new List<CountryDto>();

            foreach (var country in countries)
            {
                countriesDto.Add(new CountryDto
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }

            return Ok(countriesDto);
        }


        // api/country/countryId
        [HttpGet("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId)) return NotFound();

            var country = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var countriesDto = new List<CountryDto>();

            countriesDto.Add( new CountryDto { Id= country.Id, Name = country.Name });

            return Ok(countriesDto);
        }

        [HttpGet("author/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryOfAnAuthor(int authorId)
        {

            var country = _countryRepository.GetCountryOfAuthor(authorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDto);
        }

        //api/countries/countryId/authors
        [HttpGet("{countryId}/authors")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        public IActionResult GetAuthorsFromCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId)) return NotFound();

            var authors = _countryRepository.GetAuthorsFromACountry(countryId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var authorDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
               authorDto.Add(new AuthorDto
                {
                   Id = author.Id,
                   FirstName = author.FirstName,
                   LastName = author.LastName
                });
            }

            return Ok(authorDto);
        }

    }
}
