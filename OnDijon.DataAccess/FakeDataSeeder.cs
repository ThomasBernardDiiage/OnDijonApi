using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnDijon.Domain;

namespace OnDijon.DataAccess;

public static class FakeDataSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<OnDijonDbContext>();

            context.Database.EnsureDeleted();

            context.Database.Migrate();

            MeanOfLocomotion[] meanOfLocomotionList = { new MeanOfLocomotion { Label = "Bike" },
                 new MeanOfLocomotion { Label = "Scooter" },
                new MeanOfLocomotion { Label = "Skateboard" }};

            context.Set<MeanOfLocomotion>().AddRange(meanOfLocomotionList);

            ReasonForTravel[] reasonForTravelList = {  new ReasonForTravel { Label = "Professional" } ,
            new ReasonForTravel { Label = "Hobby" },
            new ReasonForTravel { Label = "Family" }};

            context.Set<ReasonForTravel>().AddRange(reasonForTravelList);


            var users = new Faker<User>()
                .RuleFor(u => u.Guid, f => f.Random.Guid().ToString())
                .RuleFor(u => u.Age, f => new Randomizer().Number(1, 100))
                 .RuleFor(u => u.MeanOfLocomotionId, f => new Randomizer().Number(1, meanOfLocomotionList.Length))
                .RuleFor(u => u.ReasonForTravelId, f => new Randomizer().Number(1, reasonForTravelList.Length))
                .Generate(200);

            context.Set<User>().AddRange(users);


            var shelters = new Faker<Shelter>()
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Latitude, f => f.Address.Latitude(max: 47.35955050266304, min: 47.272282728907335))
                .RuleFor(s => s.Longitude, f => f.Address.Longitude(max: 5.1158337581491375, min: 4.968862145769348))
                .RuleFor(s => s.Capacity, f => f.Random.Int(10, 100))
                .Generate(50);

            context.Set<Shelter>().AddRange(shelters);
            
            context.SaveChanges(); // IDK why but this line is required


            //var sheltersHistory = new Faker<ShelterHistory>()
            //    .RuleFor(s => s.Date, f => DateTimeOffset.UtcNow.AddDays(-f.Random.Int(1, 1000)))
            //    .RuleFor(s => s.ShelterId, f => new Randomizer().Number(1, shelters.Count))
            //    .RuleFor(s => s.IsEntry, f => f.Random.Bool(0.7f)) // 70% of true
            //    .Generate(400);
//
//
            //context.Set<ShelterHistory>().AddRange(sheltersHistory);


            var address = new Faker<Address>()
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.UserId, f => new Randomizer().Number(1, users.Count))
                .RuleFor(s => s.Latitude, f => f.Address.Latitude(max: 47.35955050266304, min: 47.272282728907335))
                .RuleFor(s => s.Longitude, f => f.Address.Longitude(max: 5.1158337581491375, min: 4.968862145769348))
                .RuleFor(s => s.Phone, f => f.Phone.PhoneNumber("06########"))
                .Generate(100);

            context.Set<Address>().AddRange(address);

            
            var shelterReport = new Faker<ShelterReporting>()
                .RuleFor(s => s.Date, f => DateTimeOffset.UtcNow.AddDays(f.Random.Number(1, 1000)))
                .RuleFor(s => s.Object, f => f.Lorem.Sentence(2))
                .RuleFor(s => s.Comment, f => f.Lorem.Sentence(10))
                .RuleFor(s => s.UserId, f => new Randomizer().Number(1, users.Count))
                .RuleFor(s => s.ShelterId, f => new Randomizer().Number(1, shelters.Count))
                .Generate(100);

            context.Set<ShelterReporting>().AddRange(shelterReport);


            context.SaveChanges();
        }
    }
}