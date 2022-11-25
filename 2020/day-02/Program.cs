public class Day2
{
    public static void Main()
    {
        int valid = 0;
        string[] lines = System.IO.File.ReadAllLines(@".\input.txt");
        foreach (string line in lines)
        {
            // get rule
            string rule = line.Split(':')[0];
            string[] ruleRange = rule.Split(' ')[0].Split('-');
            char ruleLetter = char.Parse(rule.Split(' ')[1]);

            // convert rule range to numbers
            List<int> ruleRangeNums = (Array.ConvertAll(ruleRange, s => Int32.Parse(s.Trim()))).ToList();
            int ruleRangeMin = ruleRangeNums.Min();
            int ruleRangeMax = ruleRangeNums.Max();

            // get password
            string password = line.Split(':')[1].Trim();

            // get frequency of required letter in password
            int letterFreq = password.Count(f => (f == ruleLetter));

            // check if password is valid
            // 1. check if pw contains the specified letter
            if (password.Contains(ruleLetter))
            {
                // 2. if it contains it, check if the allowed letter within allowed range
                if (ruleRangeMin <= letterFreq && letterFreq <= ruleRangeMax)
                {
                    valid += 1;
                }
            }
        }
        Console.WriteLine($"Number of valid passwords: {valid}");
    }

}