namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using ProjectCluster.Data.Models;

    public class ProjectsSeeder : ISeeder
    {
        static Random random = new Random();

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Projects.Any())
            {
                return;
            }

            for (int i = 0; i < userManager.Users.Where(x => x.UserName != "Admin").Count() - 10; i++)
            {
                var users = userManager.Users.Where(x => x.UserName != "Admin").ToList();
                var user = users[i];
                foreach (var category in dbContext.Categories)
                {
                    if (category.Name == "Animals")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("I made this toy for my dog");
                        projectTitles.Add("This is the dog house I built for Jackie");
                        projectTitles.Add("Custom food bowl for my dog");
                        projectTitles.Add("I made this sweater for my chihuahua");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600023/animal-animal-photography-boots-canine-540521_vndx99.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600141/person-petting-a-dog-on-outdoors-1397199_sgeebe.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600189/beige-and-black-coated-dog-3367616_dlq7ek.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Art")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("I made this painting");
                        projectTitles.Add("Statue I made last weekend");
                        projectTitles.Add("This is my new poster I designed myself");
                        projectTitles.Add("3D model I made for a video game");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587598517/multicolored-abstract-painting-1269968_zhn2ne.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587598797/brown-wooden-planks-889839_mjfezt.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587598862/photo-of-red-peonies-painting-1005711_exgmio.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Cars")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("I changed my wheels");
                        projectTitles.Add("Painted my car");
                        projectTitles.Add("Detailing my new car");
                        projectTitles.Add("Fixed my door dent");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1585332346/grahame-jenkins-p7tai9P7H-s-unsplash_kxgfeo.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600521/action-asphalt-automobile-automotive-627678_slqrwb.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600548/asphalt-auto-automobile-brand-244206_izif22.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "DIY")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("I made this on the weekend");
                        projectTitles.Add("Little project I made this morning");
                        projectTitles.Add("This is the gift I made for my father");
                        projectTitles.Add("Got bored and made this");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600812/two-blue-wooden-pots-1075757_uenonc.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600879/photo-of-person-holding-brown-yarn-roll-3654772_ncznvl.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587600935/watch-with-straps-beside-smartphone-on-table-982660_yjagop.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };
                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Food")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("I tried a new recipe today");
                        projectTitles.Add("This turned out so delicious!");
                        projectTitles.Add("My favourite friday night dish");
                        projectTitles.Add("I cooked this yesterday");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601046/burrito-chicken-delicious-dinner-461198_avnq4k.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601065/blur-breakfast-close-up-dairy-product-376464_qgdvzy.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601097/selective-focus-photography-of-beef-steak-with-sauce-675951_xlmepd.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Gaming")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("This happend on my last gaming session");
                        projectTitles.Add("Trying to do this on my next run");
                        projectTitles.Add("I barely had time for this");
                        projectTitles.Add("My oponent is still angry");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601277/hjl4YrilDJjPXckCNR16yQJrmVGv3F3e_cgKDPrH4sA_vwsxn2.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601324/cs-go-dust-a-spot_hjx9op.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601409/2017-02-08_11.03.51_bhauor.png");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Gardening")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("I planted this in my back yard");
                        projectTitles.Add("Some maintanance in the garden");
                        projectTitles.Add("Couldnt wait to use my new tools");
                        projectTitles.Add("Plants from my own garden");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601549/healthy-vegetables-hand-gardening-9301_k7nxgl.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601581/man-planting-plant-169523_zlnhcb.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601610/selective-focus-photography-of-green-leaf-plants-on-brown-1105017_zzc0bz.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Music")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("Some new music I composed");
                        projectTitles.Add("Bought a new instrument");
                        projectTitles.Add("Im going to give this ols instrument to my brother");
                        projectTitles.Add("Wrote a song for my girlfriend");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601732/person-playing-sun-burst-electric-bass-guitar-in-bokeh-96380_wuqkce.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601774/playing-music-musician-classic-33597_h6oeh3.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601805/brass-classic-classical-music-close-up-45243_d2m0hv.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Photography")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("Some shots I made this morning");
                        projectTitles.Add("Experimenting with my new lens");
                        projectTitles.Add("Had a blast making pictures this weekend");
                        projectTitles.Add("All of these are made with my phone");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601915/photo-of-pitched-dome-tents-overlooking-mountain-ranges-1687845_ojjvtq.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587601983/man-in-black-backpack-during-golden-hour-1230302_qvifto.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602022/body-of-water-across-forest-949194_s79lur.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Programming")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("Today I made this fun app");
                        projectTitles.Add("A project I made for university");
                        projectTitles.Add("Making a mini game");
                        projectTitles.Add("Trying to make an emulator");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602180/abstract-business-code-coder-270348_k4umaj.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602194/photo-of-turned-on-laptop-computer-943096_ol75z6.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602214/coffee-writing-computer-blogging-34600_vbgodk.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Videography")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("Some filming I did on the weekend");
                        projectTitles.Add("Practicing with the new drone");
                        projectTitles.Add("Trying to edit with new software");
                        projectTitles.Add("Making a video for my friends birthday");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602373/camera-event-live-settings-66134_ucudyu.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602394/low-angle-view-of-lighting-equipment-on-shelf-257904_gxsdwo.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602398/car-covered-with-smoke-on-pavement-1107666_wuyi4n.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                    else if (category.Name == "Writing")
                    {
                        var projectTitles = new List<string>();
                        projectTitles.Add("Writing a poem");
                        projectTitles.Add("Some of the introduction to my book");
                        projectTitles.Add("Trying to write in different languages");
                        projectTitles.Add("This is what progress I made with my book this weekend");
                        var projectPictures = new List<string>();
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602583/ballpen-blank-desk-journal-606541_w0kbva.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602587/person-holding-blue-ballpoint-pen-writing-in-notebook-210661_qwbgzi.jpg");
                        projectPictures.Add("https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587602592/black-and-white-blog-business-coffee-261579_fecnhe.jpg");
                        int rtitle = random.Next(projectTitles.Count);
                        int rpicture = random.Next(projectPictures.Count);
                        int rprogress = random.Next(100);
                        var project = new Project
                        {
                            UserId = user.Id,
                            CategoryId = category.Id,
                            Title = projectTitles[rtitle],
                            ImageUrl = projectPictures[rpicture],
                            Content = "This is my new project. I hope you like it. Make sure to comment and rate! :)",
                            Progress = rprogress,
                            ProjectStatus = rprogress == 100 ? Models.Enums.ProjectStatus.Finished :Models.Enums.ProjectStatus.InProgress,
                        };

                        await dbContext.Projects.AddAsync(project);
                    }
                }

                dbContext.SaveChanges();
            }
        }
    }
}
