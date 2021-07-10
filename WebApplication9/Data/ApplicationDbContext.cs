using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<MessageDto> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Role
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "1e67e9cd-bf7e-4621-9b04-68ed8573ad2a", Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "f8ee5677-2983-40ca-924d-fa131789457b", Name = "Candidate", NormalizedName = "Candidate".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "952428ed-d144-4b77-bb68-46557285f730", Name = "Treasurer", NormalizedName = "Treasurer".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "c9c80dbb-dea4-466c-8024-81c4d59d21ff", Name = "Officer", NormalizedName = "Officer".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "db44c661-3aa3-4f69-b766-0dcdb95f9dec", Name = "Primary Registered Lobbyist", NormalizedName = "Primary Registered Lobbyist".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "ff029abe-0cbb-41ea-9f31-65bc6c474d65", Name = "Other Lobbyost", NormalizedName = "Other Lobbyost".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "d761ae56-7978-449c-af48-8ea55cc51cf2", Name = "IE Filer Primary User", NormalizedName = "IE Filer Primary User".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "c7f1717d-10c0-418e-8ae2-d796dd8893af", Name = "IE Filer Secondary User", NormalizedName = "IE Filer Secondary User".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "878d4414-d052-4796-9128-e25811b6bde5", Name = "Ethics Primary User", NormalizedName = "Ethics Primary User".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "8afc03f5-d7f3-4358-90b2-ddbecb8fe77a", Name = "Ethics Secondary User", NormalizedName = "Ethics Secondary User".ToUpper() });
            #endregion

            #region User
            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "c2b0541f-4819-4a10-9e62-63d53c2bf8a8", // primary key
                    UserName = "admin@maplight.org",
                    NormalizedUserName = "ADMIN@MAPLIGHT.ORG",
                    Email = "admin@maplight.org",
                    NormalizedEmail = "ADMIN@MAPLIGHT.ORG",
                    EmailConfirmed = true,
                    PhoneNumber = "255684811042",
                    PasswordHash = hasher.HashPassword(null, "1234"),
                    SecurityStamp = Guid.NewGuid().ToString("D")
                });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "aff709de-7468-451e-9839-b538cc7e9941", // primary key
                     UserName = "candidate@maplight.org",
                     NormalizedUserName = "CANDIDATE@MAPLIGHT.ORG",
                     Email = "candidate@maplight.org",
                     NormalizedEmail = "CANDIDATE@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811043",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "ad89b30a-695b-4296-8a60-fd8f3f2936d7", // primary key
                     UserName = "treasurer@maplight.org",
                     NormalizedUserName = "TREASURER@MAPLIGHT.ORG",
                     Email = "treasurer@maplight.org",
                     NormalizedEmail = "TREASURER@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811044",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "1f4b26a9-d046-4513-97f8-784c4fd31486", // primary key
                     UserName = "officer@maplight.org",
                     NormalizedUserName = "OFFICER@MAPLIGHT.ORG",
                     Email = "officer@maplight.org",
                     NormalizedEmail = "OFFICER@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811045",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "23b03c1d-9439-42c3-989e-afc4caa371f6", // primary key
                     UserName = "primaryregisteredlobbyist@maplight.org",
                     NormalizedUserName = "PRIMARYREGISTEREDLOBBYIST@MAPLIGHT.ORG",
                     Email = "primaryregisteredlobbyist@maplight.org",
                     NormalizedEmail = "PRIMARYREGISTEREDLOBBYIST@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811046",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "c5facb3c-7289-4756-9afb-4e02f5a28740", // primary key
                     UserName = "otherlobbyost@maplight.org",
                     NormalizedUserName = "OTHERLOBBYOST@MAPLIGHT.ORG",
                     Email = "otherlobbyost@maplight.org",
                     NormalizedEmail = "OTHERLOBBYOST@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811047",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "0fb18dd5-9cff-4635-86d0-76416b16b570", // primary key
                     UserName = "iefilerprimaryuser@maplight.org",
                     NormalizedUserName = "IEFILERPRIMARYUSER@MAPLIGHT.ORG",
                     Email = "iefilerprimaryuser@maplight.org",
                     NormalizedEmail = "IEFILERPRIMARYUSER@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811048",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "92465d77-d88d-487a-86aa-d8783fc8702d", // primary key
                     UserName = "iefilersecondaryuser@maplight.org",
                     NormalizedUserName = "IEFILERSECONDARYUSER@MAPLIGHT.ORG",
                     Email = "iefilersecondaryuser@maplight.org",
                     NormalizedEmail = "iefilersecondaryuser@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811049",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "5f094eb0-c08c-4c95-a085-9e93638d981c", // primary key
                     UserName = "ethicsprimaryuser@maplight.org",
                     NormalizedUserName = "ETHICSPRIMARYUSER@MAPLIGHT.ORG",
                     Email = "ethicsprimaryuser@maplight.org",
                     NormalizedEmail = "ETHICSPRIMARYUSER@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811050",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });

            modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = "aac55d50-3863-47ba-bfc0-bd68c0d770af", // primary key
                     UserName = "ethicssecondaryuser@maplight.org",
                     NormalizedUserName = "ETHICSSECONDARYUSER@MAPLIGHT.ORG",
                     Email = "ethicssecondaryuser@maplight.org",
                     NormalizedEmail = "ETHICSSECONDARYUSER@MAPLIGHT.ORG",
                     EmailConfirmed = true,
                     PhoneNumber = "255684811051",
                     PasswordHash = hasher.HashPassword(null, "1234"),
                     SecurityStamp = Guid.NewGuid().ToString("D")
                 });
            #endregion

            #region User Role
            modelBuilder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole
                {
                    RoleId = "1e67e9cd-bf7e-4621-9b04-68ed8573ad2a",
                    UserId = "c2b0541f-4819-4a10-9e62-63d53c2bf8a8"
                });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
               new ApplicationUserRole
               {
                   RoleId = "f8ee5677-2983-40ca-924d-fa131789457b",
                   UserId = "aff709de-7468-451e-9839-b538cc7e9941"
               });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
              new ApplicationUserRole
              {
                  RoleId = "952428ed-d144-4b77-bb68-46557285f730",
                  UserId = "ad89b30a-695b-4296-8a60-fd8f3f2936d7"
              });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "c9c80dbb-dea4-466c-8024-81c4d59d21ff",
                 UserId = "1f4b26a9-d046-4513-97f8-784c4fd31486"
             });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "db44c661-3aa3-4f69-b766-0dcdb95f9dec",
                 UserId = "23b03c1d-9439-42c3-989e-afc4caa371f6"
             });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "ff029abe-0cbb-41ea-9f31-65bc6c474d65",
                 UserId = "c5facb3c-7289-4756-9afb-4e02f5a28740"
             });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "d761ae56-7978-449c-af48-8ea55cc51cf2",
                 UserId = "0fb18dd5-9cff-4635-86d0-76416b16b570"
             });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "c7f1717d-10c0-418e-8ae2-d796dd8893af",
                 UserId = "92465d77-d88d-487a-86aa-d8783fc8702d"
             });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "878d4414-d052-4796-9128-e25811b6bde5",
                 UserId = "5f094eb0-c08c-4c95-a085-9e93638d981c"
             });

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole
             {
                 RoleId = "8afc03f5-d7f3-4358-90b2-ddbecb8fe77a",
                 UserId = "aac55d50-3863-47ba-bfc0-bd68c0d770af"
             });

            #endregion


            base.OnModelCreating(modelBuilder);
        }
    }
}
