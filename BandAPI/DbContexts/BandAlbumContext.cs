using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BandAPI.DbContexts
{
    public class BandAlbumContext : DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) : base(options) 
        {
            
        }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band
            {
                Id = Guid.Parse("bb445fe8-381f-4e97-ac73-66bbc90d4fd6"),
                Name= "Metallica",
                Founded = new DateTime(1980, 01, 01),
                MainGener = "Heavy Metal"
            },
            new Band
            {
                Id = Guid.Parse("f3f3149d-72b9-4b8c-bf18-4452a84dbdcf"),
                Name = "Guns N Roses",
                Founded = new DateTime(1985, 02, 01),
                MainGener = "Rock"
            }
            ,
            new Band
            {
                Id = Guid.Parse("8a6e4004-2538-411c-8b63-1633a07ec5b2"),
                Name = "ABBA",
                Founded = new DateTime(1965, 07, 01),
                MainGener = "Disco"
            }
            ,
            new Band
            {
                Id = Guid.Parse("b821c173-011d-4ffe-a41a-bb377289ddbf"),
                Name = "Oasis",
                Founded = new DateTime(1991, 12, 01),
                MainGener = "Alternative"
            },
            new Band
            {
                Id = Guid.Parse("73fb4c0d-144a-4e9d-822e-206540538249"),
                Name = "A-Ha",
                Founded = new DateTime(1981, 06, 01),
                MainGener = "Pop"
            });

            modelBuilder.Entity<Album>().HasData(new Album
            {
                Id = Guid.Parse("d1b21996-8d04-4765-81e8-6708a476629b"),
                Title = "Master Of Puppets",
                Description = "One of the best heavy metal albums ever",
                BandId = Guid.Parse("bb445fe8-381f-4e97-ac73-66bbc90d4fd6")
            },new Album
            {
                Id = Guid.Parse("3dfa8c72-94db-46f3-9fe9-3c3e2344abd5"),
                Title = "Appetite for Destruction",
                Description = "Amzing Rock album with raw round",
                BandId = Guid.Parse("f3f3149d-72b9-4b8c-bf18-4452a84dbdcf")
            }, new Album
            {
                Id = Guid.Parse("efd96855-4b36-41d0-9cca-0eab30bcc4bd"),
                Title = "Waterloo",
                Description = "Very groovy album",
                BandId = Guid.Parse("8a6e4004-2538-411c-8b63-1633a07ec5b2")
            },
            new Album
            {
                Id = Guid.Parse("6b6a5d3c-1494-4b36-acd1-aba105074364"),
                Title = "Be Here Now",
                Description = "Arguably one of the best albums by Oasis",
                BandId = Guid.Parse("b821c173-011d-4ffe-a41a-bb377289ddbf")
            }, new Album
            {
                Id = Guid.Parse("0e250b09-f6e4-4be1-a858-863782e60da7"),
                Title = "Hunting Hight and Low",
                Description = "Awesome Debut album by A-ha",
                BandId = Guid.Parse("73fb4c0d-144a-4e9d-822e-206540538249")
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
