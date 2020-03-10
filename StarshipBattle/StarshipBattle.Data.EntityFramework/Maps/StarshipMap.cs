using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarshipBattle.Data.Entites;

namespace StarshipBattle.Data.EntityFramework.Maps
{
    internal class StarshipMap : IEntityTypeConfiguration<Starship>
    {
        public void Configure(EntityTypeBuilder<Starship> builder)
        {
            builder.ToTable("Starship");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired();

            builder.Property(m => m.Name).IsRequired();

            builder.Property(m => m.CrewQuantity).IsRequired();
        }
    }
}
