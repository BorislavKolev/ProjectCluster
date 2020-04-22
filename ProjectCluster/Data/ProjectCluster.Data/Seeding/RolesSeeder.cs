namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using ProjectCluster.Common;
    using ProjectCluster.Data.Models;

    internal class RolesSeeder : ISeeder
    {
        private readonly IConfiguration configuration;

        public RolesSeeder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(roleManager, this.configuration["AdminInfo:AdministratorRoleName"]);
            await SeedRoleAsync(roleManager, this.configuration["UserInfo:UserRoleName"]);
            await SeedUsersInAdministratorRole(userManager, this.configuration["AdminInfo:AdministratorUsername"], this.configuration["AdminInfo:AdministratorEmail"], this.configuration["AdminInfo:AdministratorPassword"], this.configuration["AdminInfo:AdministratorRoleName"]);
            await SeedUsersInUserRole(userManager, this.configuration["UserInfo:UserRoleName"], this.configuration["UserInfo:UserPassword"]);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedUsersInAdministratorRole(UserManager<ApplicationUser> userManager, string adminUsername, string adminEmail, string adminPassword, string adminRolename)
        {
            if (!userManager.Users.Any(x => x.UserName == adminUsername))
            {
                var user = new ApplicationUser
                {
                    UserName = adminUsername,
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRolename);
                }
                else
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedUsersInUserRole(UserManager<ApplicationUser> userManager, string userRoleName, string userPassword)
        {
            var userData = new[] { new { name = "Signe", email = "vitae.sodales.nisi@pedeac.net" }, new { name = "Harper", email = "sodales.elit.erat@aliquam.co.uk" }, new { name = "Adena", email = "tellus@necdiamDuis.org" }, new { name = "Ruby", email = "non.luctus.sit@egestas.net" }, new { name = "Mikaylas", email = "ante.bibendum.ullamcorper@eteuismodet.net" }, new { name = "Quinlan", email = "Praesent.interdum.ligula@necmauris.co.uk" }, new { name = "Quynn", email = "vitae@rutrum.com" }, new { name = "Thor", email = "elit@rhoncusDonecest.com" }, new { name = "Lance", email = "a@InloremDonec.edu" }, new { name = "Autumn", email = "nec@Class.net" }, new { name = "Arsenio", email = "et@ac.org" }, new { name = "Sharon", email = "et.netus@scelerisqueduiSuspendisse.net" }, new { name = "Ursa", email = "eu@fringillapurus.edu" }, new { name = "Emi", email = "vulputate.posuere.vulputate@orciluctuset.net" }, new { name = "Olympia", email = "egestas.hendrerit@urnanec.edu" }, new { name = "Fay", email = "quam.a@urnajustofaucibus.ca" }, new { name = "Clark", email = "faucibus.leo.in@velit.org" }, new { name = "Elton", email = "vulputate.ullamcorper.magna@rhoncus.co.uk" }, new { name = "Scarlett", email = "consectetuer@utdolordapibus.edu" }, new { name = "Rhona", email = "aliquet.metus@ametdapibusid.org" }, new { name = "Baker", email = "non.egestas.a@nibhsit.co.uk" }, new { name = "Maryam", email = "Nunc@acturpisegestas.com" }, new { name = "Jack", email = "erat.nonummy@utdolor.co.uk" }, new { name = "Zelda", email = "Integer@Etiam.com" }, new { name = "Micah", email = "nonummy.Fusce@pede.ca" }, new { name = "Lynn", email = "consectetuer.adipiscing.elit@Suspendissealiquet.net" }, new { name = "Cedric", email = "urna@pretiumaliquetmetus.com" }, new { name = "Beau", email = "ac.sem@anuncIn.org" }, new { name = "Wylie", email = "Nullam@ametloremsemper.net" }, new { name = "Sonia", email = "a.aliquet@Aenean.ca" }, new { name = "Freya", email = "risus.Nulla@Utnec.co.uk" }, new { name = "Serena", email = "magna@faucibusid.com" }, new { name = "Hadassah", email = "tristique.senectus@consequatnecmollis.com" }, new { name = "Imar", email = "Ut.tincidunt@Craseu.co.uk" }, new { name = "Melodie", email = "amet.faucibus.ut@Donecnon.co.uk" }, new { name = "Mikayla", email = "ac@aliquam.co.uk" }, new { name = "Tanek", email = "rutrum@in.org" }, new { name = "Cyrus", email = "nec@Fuscedolorquam.org" }, new { name = "Nora", email = "Nam.tempor.diam@ametmetusAliquam.edu" }, new { name = "Philip", email = "quam.vel@laoreetlibero.org" }, new { name = "Calvin", email = "morbi@fermentumarcu.ca" }, new { name = "Reese", email = "orci@eu.com" }, new { name = "Caryn", email = "vel.nisl@sitamet.com" }, new { name = "Cora", email = "metus.eu@malesuadafamesac.net" }, new { name = "Damon", email = "quis.diam.Pellentesque@egestasFusce.org" }, new { name = "Sloane", email = "metus@consequatnecmollis.org" }, new { name = "Ima", email = "et.arcu@molestie.co.uk" }, new { name = "Clarker", email = "dictum.eleifend.nunc@uteros.ca" }, new { name = "Ifeoma", email = "malesuada@disparturientmontes.net" }, new { name = "Carson", email = "neque@imperdietnon.edu" }, new { name = "Sylvester", email = "neque@ataugueid.ca" }, new { name = "Angela", email = "Aliquam@Phaselluslibero.com" }, new { name = "Bethany", email = "sollicitudin@nequeInornare.org" }, new { name = "Echo", email = "aliquet.metus.urna@convallis.com" }, new { name = "Cooper", email = "Aliquam.tincidunt@pedeCras.edu" }, new { name = "John", email = "quam.a@arcuVestibulum.org" }, new { name = "Hamish", email = "Nulla.tempor@Nuncmauriselit.com" }, new { name = "Sade", email = "Quisque.ac@sagittisaugueeu.co.uk" }, new { name = "Leo", email = "nec.urna.et@justositamet.edu" }, new { name = "Preston", email = "tincidunt.nunc.ac@parturient.com" }, new { name = "Vivien", email = "sapien.imperdiet@nuncid.edu" }, new { name = "Bruce", email = "neque@scelerisquelorem.co.uk" }, new { name = "Quinn", email = "lacinia@Loremipsumdolor.edu" }, new { name = "Jared", email = "ullamcorper.eu@posuerecubilia.net" }, new { name = "Damony", email = "dui.nec@luctuslobortis.net" }, new { name = "Lucy", email = "malesuada.vel.convallis@DonecegestasAliquam.org" }, new { name = "Uriah", email = "elit.pretium@tellus.com" }, new { name = "Dale", email = "Phasellus.vitae@sitamet.org" }, new { name = "Donovan", email = "pede.Cras@dictumplacerat.ca" }, new { name = "Brandon", email = "aliquet@lacusQuisque.ca" }, new { name = "Hermione", email = "mi.fringilla.mi@scelerisqueneque.ca" }, new { name = "Gailk", email = "pede@ipsum.ca" }, new { name = "Adria", email = "mus@Nullam.net" }, new { name = "Alyssa", email = "Etiam.laoreet@justositamet.org" }, new { name = "Harlan", email = "in.consectetuer.ipsum@quismassa.ca" }, new { name = "David", email = "Morbi.sit@massalobortis.co.uk" }, new { name = "Garth", email = "ut.quam.vel@egestasblandit.ca" }, new { name = "Aretha", email = "arcu@Duisdignissimtempor.org" }, new { name = "Beck", email = "amet@nec.org" }, new { name = "Kasimir", email = "orci@enimnectempus.co.uk" }, new { name = "Tate", email = "Phasellus.libero@dolor.net" }, new { name = "Michelle", email = "et@Donecnibh.com" }, new { name = "Jennifer", email = "a@risusIn.ca" }, new { name = "Lavinia", email = "sit.amet.nulla@Sednullaante.com" }, new { name = "Rudyard", email = "vulputate@magnaNam.com" }, new { name = "Barbara", email = "nunc@Sedeu.edu" }, new { name = "Amos", email = "vel.turpis.Aliquam@posuereenimnisl.ca" }, new { name = "Gil", email = "tincidunt.Donec@nonluctussit.com" }, new { name = "Gregory", email = "est.ac@senectusetnetus.edu" }, new { name = "Laura", email = "cursus@semperauctorMauris.edu" }, new { name = "Sarah", email = "dis.parturient.montes@sociosquad.org" }, new { name = "Amir", email = "lorem.sit.amet@Nuncullamcorper.com" }, new { name = "Gail", email = "dolor@urna.com" }, new { name = "Vanna", email = "hendrerit.id.ante@aliquam.ca" }, new { name = "Christopher", email = "In.ornare@ac.ca" }, new { name = "Amye", email = "orci.Phasellus@pharetraNam.org" }, new { name = "Erin", email = "Morbi.neque.tellus@Etiamlaoreet.ca" }, new { name = "Igor", email = "vitae@tellus.edu" }, new { name = "Yasir", email = "malesuada.id@malesuadafringillaest.ca" }, new { name = "Kaden", email = "tellus.Phasellus.elit@Integerin.com" } };

            var usersCount = userManager.GetUsersInRoleAsync(userRoleName).GetAwaiter().GetResult().Count();

            if (usersCount == 0)
            {
                foreach (var item in userData)
                {
                    var user = new ApplicationUser
                    {
                        UserName = item.name,
                        Email = item.email,
                        AvatarUrl = "https://res.cloudinary.com/sharwinchester/image/upload/v1587592729/Administrative/avatar_pnsyjm.png",
                        Description = $"Hi! I'm {item.name} and I really enjoy using this website!",
                    };

                    var result = await userManager.CreateAsync(user, userPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, userRoleName);
                    }
                    else
                    {
                        throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                    }
                }
            }
        }
    }
}
