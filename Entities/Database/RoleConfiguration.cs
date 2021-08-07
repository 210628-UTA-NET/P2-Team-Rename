using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Database {
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole> {
        public void Configure(EntityTypeBuilder<IdentityRole> builder) {
            builder.HasData(
                new IdentityRole {
                    Name = "Tutor",
                    NormalizedName = "TUTOR"
                },
                new IdentityRole {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}