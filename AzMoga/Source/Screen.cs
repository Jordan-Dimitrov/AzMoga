using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    enum ScreenState
    {
        MainMenu = 0,
        Game,
        EndScreen,
        Instructions,
        Stats,
        GameSettings
    }

    abstract class Screen
    {
        public Screen(int left, int top)
        {
            _Left = left;
            _Top = top;
        }

        protected bool IsKeyValid(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key != ConsoleKey.DownArrow && keyInfo.Key != ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void Draw();
        public abstract void Update();

        protected int _Left, _Top;
    }

    static class ScreenManager
    {
        public static void AddScreen(ScreenState state, Screen screen)
        {
            _Screens.Add(state, screen);
        }

        public static void Update() 
        {
            if (_Screens.ContainsKey(CurrentState))
                _Screens[CurrentState].Update();
        }

        public static void Draw()
        {
            if (_Screens.ContainsKey(CurrentState))
                _Screens[CurrentState].Draw();
        }

        public static ScreenState CurrentState 
        {
            get 
            {
                return _CurrentState;
            }
            set 
            {
                _CurrentState = value;
                Console.Clear() ;
            }
        }

        private static ScreenState _CurrentState;
        private static Dictionary<ScreenState, Screen> _Screens;
    }
}
