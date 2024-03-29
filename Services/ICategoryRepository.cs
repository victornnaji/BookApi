﻿using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        ICollection<Category> GetCategoriesOfABook(int BookId);
        ICollection<Book> GetBooksForCategory(int categoryId);
        bool CategoryExists(int CategoryId);

    }
}
