using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class Player
    {
        public Player(int x, int y, string icon, string visitedIcon) 
        {
            X = x;
            Y = y;
            Score = 0;
            Icon = icon;
            VisitedIcon = visitedIcon;
        }

        public int X, Y;
        public int Score;
        public string Icon, VisitedIcon;
    }
}
