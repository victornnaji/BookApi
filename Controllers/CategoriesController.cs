using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Dtos;
using BookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var categoriesDto = new List<CategoryDto>();

            foreach(var category in categories)
            {
                categoriesDto.Add(new CategoryDto { Id = category.Id, Name = category.Name });
            }

            return Ok(categoriesDto);
        }

        // GET: api/Categories/5
        [HttpGet("{categoryId}" )]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId)) return NotFound();

            var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var categoryDto = new List<CategoryDto>();

            categoryDto.Add(new CategoryDto { Id =category.Id, Name=category.Name});

            return Ok(categoryDto);
        }

        //GET: api/categories/books/bookId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategoriesOfABook(int bookId)
        {

            var categories = _categoryRepository.GetCategoriesOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto { Id = category.Id, Name = category.Name });
            }

            return Ok(categoriesDto);

        }

        //GET: api/categories/categoryId/books
        [HttpGet("{categoryId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public IActionResult GetBooksFromCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId)) return NotFound();

            var books = _categoryRepository.GetBooksForCategory(categoryId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookDto = new List<BookDto>();

            foreach (var book in books)
            {
                bookDto.Add(new BookDto
                {
                    Id = book.Id,
                    Isbn = book.Isbn,
                    Title = book.Title,
                    DatePublished = book.DatePublished
                });
            }

            return Ok(bookDto);
        }

    }
}
