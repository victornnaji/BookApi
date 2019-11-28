using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class CountryRepository : IcountryRepository
    {
        private BookDbContext _countryContext;

        public CountryRepository(BookDbContext countryContext)
        {
            _countryContext = countryContext;
        }
        public ICollection<Author> GetAuthorsFromACountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Country> GetCountries()
        {
            return _countryContext.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _countryContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryOfAuthor(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}
