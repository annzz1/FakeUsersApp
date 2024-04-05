using FakeUsersApp.Enums;
using System.Collections.Generic;

namespace FakeUsersApp.Models
{
    public class FakeDataViewModel
    {
      
        public Country SelectedCountry { get; set; }
        public int Seed { get; set; }
        public double ErrorProbability { get; set; }
        public double ErrorPerRecord { get; set; }
        public List<PersonModel> FakePeople { get; set; } = new List<PersonModel>();
        
    }
}