using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.BL
{
    public class PlayerInfo : IPlayerInfo
    {
        private int _playerScore;
        public int GetScore()
        {
            return _playerScore;
        }

        public void SetScore(int score)
        {
            _playerScore = score;
        }
    }
}
