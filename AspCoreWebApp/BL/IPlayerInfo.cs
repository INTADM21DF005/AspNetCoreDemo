using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.BL
{
    public interface IPlayerInfo
    {
        int GetScore();
        void SetScore(int score);
    }
}
