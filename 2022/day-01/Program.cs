class Day1
{
    public static void Main()
    {
        string[] lines = System.IO.File.ReadAllLines(@".\input.txt");
        Console.WriteLine("--------- Day 1 2022 ----------");
        Console.WriteLine($"Part one solution: {PartOne(lines)}");
        Console.WriteLine($"Part two solution: {PartTwo(lines)}");
        Console.WriteLine("-------------------------------");

        // helper function to get the sum of all elves' calories
        static List<int> SumOfCalories(string[] lines)
        {
            // create sublist for each elf
            var elfCals = lines.Aggregate(new List<List<string>> { new List<string>() },
                                (list, value) =>
                                {
                                    list.Last().Add(value);
                                    if (value == "") list.Add(new List<string>());
                                    return list;
                                });

            // iterate through each sublist
            var elfCaloriesSum = new List<int>();
            foreach (List<string> elf in elfCals)
            {

                // remove whitespace
                elf.RemoveAll(string.IsNullOrWhiteSpace);

                // convert list of strings to ints
                List<int> elfCal = elf.Select(int.Parse).ToList();

                // calculate total calories per elf (list)
                int elfCalSum = elfCal.Sum();

                // add to a list
                elfCaloriesSum.Add(elfCalSum);
            }
            return elfCaloriesSum;
        }

        static int PartOne(string[] lines)
        {
            var elfCaloriesSum = SumOfCalories(lines);
            // return the largest sum of calories
            return elfCaloriesSum.Max();
        }
        static int PartTwo(string[] lines)
        {
            var elfCaloriesSum = SumOfCalories(lines);
            // return the three largest sum of calories
            elfCaloriesSum.Sort();
            // move largest to the front
            elfCaloriesSum.Reverse();
            // return the sum of the first three elements (largest)
            return elfCaloriesSum.Take(3).Sum();
        }



    }
}