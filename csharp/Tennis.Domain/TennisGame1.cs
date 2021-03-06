using System;

namespace Tennis.Domain
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            Console.WriteLine($"New {nameof(TennisGame1)} with {player1Name} & {player2Name}");

            this.player1Name = player1Name;
            Console.WriteLine($"New {nameof(this.player1Name)} equals {player1Name}");

            this.player2Name = player2Name;
            Console.WriteLine($"New {nameof(this.player2Name)} equals {player2Name}");
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                m_score1 += 1;
                Console.WriteLine($"{nameof(playerName)} is {playerName}, " +
                                  $"{nameof(m_score1)} incremented to {m_score1}");
            }
            else
            {
                m_score2 += 1;
                Console.WriteLine($"{nameof(playerName)} is not player1, " +
                                  $"{nameof(m_score2)} incremented to {m_score2}");
            }
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }

            Console.WriteLine(nameof(GetScore) + " returned " + score);
            return score;
        }
    }
}

