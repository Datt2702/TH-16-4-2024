using System;
using Microsoft.EntityFrameworkCore;
using ThucHanhAPI.Models;

namespace ThucHanhAPI.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FullName = "FuJiko F Jujio",

                },
                new Author
                {
                    Id = 2,
                    FullName = "Takahashi Kazuki",

                });

            _builder.Entity<Book>().HasData(
                new Book
                {
                    ID = 1,
                    Title = "Doraemon",
                    Description = "Doraemon the robot cat from the future",

                    PublisherID = 1,

                },
                new Book
                {
                    ID = 2,
                    Title = "YuGiOh",
                    Description = "Yugioh magic card duel ",

                    PublisherID = 2,

                });
        }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage