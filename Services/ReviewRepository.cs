using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private BookDbContext _reviewRepository;
        public ReviewRepository(BookDbContext reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public Book GetBookOfAReview(int reviewId)
        {
            var bookId = _reviewRepository.Reviews.Where(rv => rv.Id == reviewId).Select(b => b.Book.Id).FirstOrDefault();
            return _reviewRepository.Book.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return _reviewRepository.Reviews.Where(rv => rv.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _reviewRepository.Reviews.OrderBy(rv => rv.Id).ToList();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            return _reviewRepository.Reviews.Where(bk => bk.Book.Id == bookId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewRepository.Reviews.Any(rv => rv.Id == reviewId);
        }
    }
}
