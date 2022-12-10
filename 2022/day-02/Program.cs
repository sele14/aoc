class Day2
{
    public static void Main()
    {
        string[] lines = System.IO.File.ReadAllLines(@".\input.txt");
        Console.WriteLine("--------- Day 2 2022 ----------");
        Console.WriteLine($"Part one solution: {PartOne(lines)}");
        Console.WriteLine($"Part two solution: {PartTwo(lines)}");
        Console.WriteLine("-------------------------------");

        // function that can determine number of points a  player wins in rock paper scissors (RPS) per round
        // note: score is calculated as if playerTwo is the player running the script
        static int RPSSolver(string playerOne, string playerTwo)
        {
            if (playerOne == "A")
            {
                // rock + rock
                if (playerTwo == "X")
                {
                    // rock (1) + draw (3)
                    return 1 + 3;
                }
                // rock + paper
                else if (playerTwo == "Y")
                {
                    // paper (2) + win (6)
                    return 2 + 6;
                }
                // rock + scissors
                else if (playerTwo == "Z")
                {
                    // scissors (3) vs loss (0)
                    return 3 + 0;
                }
            }
            else if (playerOne == "B")
            {
                // paper + rock
                if (playerTwo == "X")
                {
                    // rock (1) + loss (0)
                    return 1 + 0;
                }
                // paper + paper
                else if (playerTwo == "Y")
                {
                    // paper (2) + draw (3)
                    return 2 + 3;
                }
                // paper + scissors
                else if (playerTwo == "Z")
                {
                    // scissors (3) vs win (6)
                    return 3 + 6;
                }
            }
            else
            {
                // scissors + rock
                if (playerTwo == "X")
                {
                    // rock (1) + win (6)
                    return 1 + 6;
                }
                // scissors + paper
                else if (playerTwo == "Y")
                {
                    // paper (2) vs loss (0)
                    return 2 + 0;
                }
                // scissors + scissors
                else if (playerTwo == "Z")
                {
                    // scissors (3) + draw (3)
                    return 3 + 3;
                }
            }
            return 0;
        }

        // same as above except now X == lose, Y==draw, Z==win
        static int RPSResult(string playerOne, string outcome)
        {
            if (playerOne == "A")
            {
                // rock + lose
                if (outcome == "X")
                {
                    // scissors (3) + lose (0)
                    return 3 + 0;
                }
                // rock + draw
                else if (outcome == "Y")
                {
                    // rock (1) + draw (3)
                    return 1 + 3;
                }
                // rock + win
                else if (outcome == "Z")
                {
                    // paper (2) vs win (6)
                    return 2 + 6;
                }
            }
            else if (playerOne == "B")
            {
                // paper + loss
                if (outcome == "X")
                {
                    // rock (1) + loss (0)
                    return 1 + 0;
                }
                // paper + draw
                else if (outcome == "Y")
                {
                    // paper (2) + draw (3)
                    return 2 + 3;
                }
                // paper + win
                else if (outcome == "Z")
                {
                    // scissors (3) vs win (6)
                    return 3 + 6;
                }
            }
            else
            {
                // scissors + loss
                if (outcome == "X")
                {
                    // paper (2) + loss (0)
                    return 2 + 0;
                }
                // scissors + draw
                else if (outcome == "Y")
                {
                    // scissors (3) vs draw (3)
                    return 3 + 3;
                }
                // scissors + win
                else if (outcome == "Z")
                {
                    // rock (1) + win (6)
                    return 1 + 6;
                }
            }
            return 0;
        }
        static int PartOne(string[] rounds)
        {
            int score = 0;
            foreach (string round in rounds)
            {
                // isolate each player's choice for each round
                string[] plays = round.Split(' ');
                string playerOne = plays[0];
                string playerTwo = plays[1];
                score += RPSSolver(playerOne, playerTwo);
            }
            return score;
        }
        static int PartTwo(string[] rounds)
        {
            int score = 0;
            foreach (string round in rounds)
            {
                // isolate player choice and outcome
                string[] plays = round.Split(' ');
                string playerOne = plays[0];
                string outcome = plays[1];
                score += RPSResult(playerOne, outcome);
            }
            return score;
        }
    }
}