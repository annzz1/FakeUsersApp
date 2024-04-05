using Bogus;
using FakeUsersApp.Enums;
using FakeUsersApp.Models;
using System.Security.Cryptography;

public class FakeDataGenerator
{
    private static readonly Dictionary<Country, Faker<PersonModel>> CountryFakers = new Dictionary<Country, Faker<PersonModel>>
    {
        { Country.Georgia, new Faker<PersonModel>("ge") },
        { Country.USA, new Faker<PersonModel>("en_US") },
        { Country.Italy, new Faker<PersonModel>("it") }
    };

    public List<PersonModel> GenerateData(Country country, int count, int seed, double errorProbability)
    {
       
        var faker = CountryFakers[country].UseSeed(seed);
        if (faker == null)
        {
            throw new ArgumentException("Invalid country specified.");
        }

        // Ensure consistent error generation by using the seeded random number generator
        faker
            .RuleFor(x => x.FirstName, f => ErrorGenerator.IntroduceErrors(f.Name.FirstName(), errorProbability, seed))
            .RuleFor(x => x.MiddleName, f => ErrorGenerator.IntroduceErrors(f.Name.FirstName(), errorProbability, seed))
            .RuleFor(x => x.LastName, f => ErrorGenerator.IntroduceErrors(f.Name.LastName(), errorProbability, seed))
            .RuleFor(x => x.PhoneNumber, f => ErrorGenerator.IntroduceErrors(f.Phone.PhoneNumber(), errorProbability, seed))
            .RuleFor(x => x.City, f => ErrorGenerator.IntroduceErrors(f.Address.City(), errorProbability, seed))
            .RuleFor(x => x.Street, f => ErrorGenerator.IntroduceErrors(f.Address.StreetAddress(), errorProbability, seed))
            .RuleFor(x => x.Building, f => ErrorGenerator.IntroduceErrors(f.Address.BuildingNumber(), errorProbability, seed))
            .RuleFor(x => x.Appartament, f => ErrorGenerator.IntroduceErrors(f.Address.SecondaryAddress(), errorProbability, seed))
            .RuleFor(x => x.ZipCode, f => ErrorGenerator.IntroduceErrors(f.Address.ZipCode(), errorProbability, seed));

        if (country == Country.USA)
        {
            faker.RuleFor(x => x.State, f => ErrorGenerator.IntroduceErrors(f.Address.StateAbbr(), errorProbability, seed));
        }

        var fakePersonList = faker.Generate(count);

        // Generate deterministic GUIDs based on the seed value
        for (int i = 0; i < fakePersonList.Count; i++)
        {
            fakePersonList[i].Id = GetDeterministicGuid(seed, i).ToString();
        }

        return fakePersonList;
    }

    private Guid GetDeterministicGuid(int seed, int index)
    {
        // Create a deterministic GUID based on the seed and index
        var seedBytes = BitConverter.GetBytes(seed);
        var indexBytes = BitConverter.GetBytes(index);
        var combinedBytes = new byte[seedBytes.Length + indexBytes.Length];
        Array.Copy(seedBytes, 0, combinedBytes, 0, seedBytes.Length);
        Array.Copy(indexBytes, 0, combinedBytes, seedBytes.Length, indexBytes.Length);

        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(combinedBytes);
            return new Guid(hash.Take(16).ToArray());
        }
    }
}