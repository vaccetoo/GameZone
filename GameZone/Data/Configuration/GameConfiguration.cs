using GameZone.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasOne(game => game.Publisher)
                .WithMany()
                .HasForeignKey(game => game.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(game => game.Genre)
                .WithMany(genre => genre.Games)
                .HasForeignKey(game => game.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
