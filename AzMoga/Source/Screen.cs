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

        public virtual void Start() { }
        public abstract void Draw();
        public abstract void Update();

        protected int _Left, _Top;
    }

    static class ScreenManager
    {
        public static void Init() 
        {
            _Screens = new Dictionary<ScreenState, Screen>();
        }

        public static void AddScreen(ScreenState state, Screen screen)
        {
            _Screens.Add(state, screen);
        }

        public static void UpdateCurrentScreen() 
        {
            if (_Screens.ContainsKey(_CurrentState))
                _Screens[_CurrentState].Update();
        }

        public static void DrawCurrentScreen()
        {
            if (_Screens.ContainsKey(_CurrentState))
                _Screens[_CurrentState].Draw();
        }

        private static void StartCurrentScreen() 
        {
            if (_Screens.ContainsKey(_CurrentState))
                _Screens[_CurrentState].Start();
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
                Console.Clear();
                StartCurrentScreen();
            }
        }

        private static ScreenState _CurrentState;
        private static Dictionary<ScreenState, Screen> _Screens;
    }
}
