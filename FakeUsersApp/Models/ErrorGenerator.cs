using System;
using System.Text;

namespace FakeUsersApp.Models
{
    public class ErrorGenerator
    {
        public static string IntroduceErrors(string input, double errorProbability, int seed)
        {
            
            Random random = new Random(seed);

            if (errorProbability <= 0)
                return input;

            StringBuilder sb = new StringBuilder(input);
            int errorCount = CalculateErrorCount(input.Length, errorProbability);

            for (int i = 0; i < errorCount; i++)
            {
                int errorType = random.Next(3);
                switch (errorType)
                {
                    case 0:
                        DeleteCharacter(sb, random);
                        break;
                    case 1:
                        AddRandomCharacter(sb, random);
                        break;
                    case 2:
                        SwapNearbyCharacters(sb, random);
                        break;
                }
            }

            return sb.ToString();
        }

        private static int CalculateErrorCount(int length, double errorProbability)
        {
            return (int)Math.Round(length * errorProbability);
        }

        private static void DeleteCharacter(StringBuilder sb, Random random)
        {
            if (sb.Length > 0)
            {
                int index = random.Next(sb.Length);
                sb.Remove(index, 1);
            }
        }

        private static void AddRandomCharacter(StringBuilder sb, Random random)
        {
            int index = random.Next(sb.Length + 1);
            char randomChar = GenerateRandomChar(random);
            sb.Insert(index, randomChar);
        }

        private static void SwapNearbyCharacters(StringBuilder sb, Random random)
        {
            if (sb.Length > 1)
            {
                int index = random.Next(sb.Length - 1);
                char temp = sb[index];
                sb[index] = sb[index + 1];
                sb[index + 1] = temp;
            }
        }

        private static char GenerateRandomChar(Random random)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return chars[random.Next(chars.Length)];
        }
    }
}