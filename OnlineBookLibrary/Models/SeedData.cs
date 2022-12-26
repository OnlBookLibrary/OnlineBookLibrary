using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookLibrary.Data;
using OnlineBookLibrary.Models;
using System;
using System.Linq;

namespace OnlineBookLibrary.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new OnlineBookLibraryContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<OnlineBookLibraryContext>>()))
        {

            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                 new User
                {
                    
                    Name = "Dinh Quang Anh",
                    Level = 1,
                    Address = "Ninh Binh",
                    Phone = "0395100761",
                    Email = "anhdqth2109005@fpt.edu.vn",
                    LoginName = "anhdqth",
                    Password = "123456"
                },
                new User {
                    
                    Name = "Nguyen Quoc Anh",
                    Level = 1,
                    Address = "Nam Dinh",
                    Phone = "0395100761",
                    Email = "anhnqth2109005@fpt.edu.vn",
                    LoginName = "anhnqth",
                    Password = "123456"
                },
                new User {
                    
                    Name = "Nguyen Ba Khanh",
                    Level = 2,
                    Address = "Ha Noi",
                    Phone = "0395100761",
                    Email = "Khanhnbth2109005@fpt.edu.vn",
                    LoginName = "khanhnbth",
                    Password = "123456"
                },
                new User {
                    
                    Name = "Luong Viet Hoang",
                    Level = 3,
                    Address = "Binh Duong",
                    Phone = "0395100761",
                    Email = "Hoanglvth2109005@fpt.edu.vn",
                    LoginName = "hoanglvth",
                    Password = "123456"
                }
            };
            foreach(User u in users)
            {
                context.User.Add(u);
            }
            context.SaveChanges();

            var genres = new Genre[]
            {
                 new Genre { Name = "Truyen Tranh" },
                new Genre { Name = "Tieu Thuyet Trinh Tham" },
                new Genre { Name = "Tieu Thuyet Ngon Tinh" },
                new Genre { Name = "Khoa Hoc" },
                new Genre { Name = "Vat Ly" },
                new Genre { Name = "Toan Hoc" }
            };
            foreach(Genre g in genres)
            {
                context.Genre.Add(g);
            }
            context.SaveChanges();

            var books = new Book[]
            {
                new Book
                {
                    
                    Title = "Doraemon",
                    Author = "Kiriko Sensei",
                    Description = "Truyen ke ve nhung chuyen phieu luu cua chu meo may toi tu tuong lai Doraemon cung nhung nguoi ban.",
                    Image = "dang cap nhat",
                    Price = 9.99,
                    status = "abc",
                    GenreId = genres.Single(g => g.Name == "Truyen Tranh").Id
                },
                new Book
                {
                    
                    Title = "Doc La Binh Duong",
                    Author = "Luong Viet Hoang",
                    Description = "Truyen ke ve nhung thu doc la o noi khac nhung lai rat binh thuong o Binh Duong.",
                    Image = "dang cap nhat",
                    Price = 9.99,
                    status = "cbc",
                    GenreId = genres.Single(g => g.Name == "Tieu Thuyet Trinh Tham").Id
                },
                new Book
                {

                    
                    Title = "10h Toi Thu 6",
                    Author = "Nguyen Dac Dung",
                    Description = "Khon co gi de noi het.",
                    Image = "dang cap nhat",
                    Price = 9.99,
                    status = "asd",
                    GenreId = genres.Single(g => g.Name == "Tieu Thuyet Ngon Tinh").Id
                },
                new Book
                {
                    
                    Title = "Khoang Khong Vo Tan",
                    Author = "Ely Tran",
                    Description = "Khong co mo ta gi het.",
                    Image = "dang cap nhat",
                    Price = 9.99,
                    status = "add",
                    GenreId = genres.Single(g => g.Name == "Khoa Hoc").Id
                },
                new Book
                {
                    
                    Title = "Vat Ly Vui",
                    Author = "Anonymous",
                    Description = "ff",
                    Image = "dang cap nhat",
                    Price = 9.99,
                    status = "ada",
                    GenreId = genres.Single(g => g.Name == "Vat Ly").Id
                },
                new Book
                {
                    
                    Title = "Tap Chi Toan Hoc",
                    Author = "mr.dam",
                    Description = "ffffff",
                    Image = "dang cap nhat",
                    Price = 9.99,
                    status = "ada",
                    GenreId = genres.Single(g => g.Name == "Toan Hoc").Id
                }
            };
            foreach(Book b in books)
            {
                context.Book.Add(b);
            }

            context.SaveChanges();
        }
    }
}
