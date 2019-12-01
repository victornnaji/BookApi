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
    public class ReviewsController : ControllerBase
    {
        private IReviewRepository _reviewRepository;
        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/Reviews
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();

            if (!ModelState.IsValid) return BadRequest();

            var reviewDto = new List<ReviewDto>();

            foreach(var review in reviews)
            {
                reviewDto.Add(new ReviewDto { Id = review.Id, Headline = review.Headline, ReviewText = review.ReviewText });
            }

            return Ok(reviewDto);
        }

        //GET: api/reviews/reviewId
        [HttpGet("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId)) return NotFound();

            var review = _reviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid) return BadRequest();

            var reviewDto = new ReviewDto { Id = review.Id, Headline = review.Headline, ReviewText = review.ReviewText };

            return Ok(reviewDto);
        }

        //GET: api/reviews/reviewId/book
        [HttpGet("{reviewId}/book")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBookOfAReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId)) return NotFound();

            var book = _reviewRepository.GetBookOfAReview(reviewId);

            if (!ModelState.IsValid) return BadRequest();

            var bookDto = new BookDto { Id = book.Id, Isbn = book.Isbn, Title = book.Title, DatePublished = book.DatePublished };

            return Ok(bookDto);
        }


    }
}
