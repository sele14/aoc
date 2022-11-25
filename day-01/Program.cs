class Day1
{
    public static void Main()
    {
        string[] lines = System.IO.File.ReadAllLines(@".\input.txt");

        // convert input to numbers
        List<int> linesNum = (Array.ConvertAll(lines, s => Int32.Parse(s))).ToList();
        linesNum.Sort();

        Console.WriteLine("########## Day 1 2020 ##########");
        Console.WriteLine($"Part one solution: {PartOne(linesNum)}");
        Console.WriteLine($"Part two solution: {PartTwo(linesNum)}");
        Console.WriteLine("################################");


        static int PartOne(List<int> list)
        {
            foreach (int x in list)
            {
                foreach (int y in list)
                {
                    if (x + y == 2020)
                    {
                        return x * y;
                    }
                }
            }
            return 0;
        }

        static int PartTwo(List<int> list)
        {
            foreach (int x in list)
            {
                foreach (int y in list)
                {
                    foreach (int z in list)
                    {
                        if (x + y + z == 2020)
                        {
                            return x * y * z;
                        }
                    }
                }
            }
            return 0;
        }

    }
}