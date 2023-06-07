using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    class MathTricks
    {
        public MathTricks()
        {
            ScreenManager.Init();
            ScreenManager.AddScreen(ScreenState.MainMenu, new MainMenu(1, 1));
            ScreenManager.AddScreen(ScreenState.Game, new Game());
            ScreenManager.AddScreen(ScreenState.EndScreen, new EndScreen());
            ScreenManager.AddScreen(ScreenState.GameSettings, new SettingsScreen(0, 0));
            ScreenManager.AddScreen(ScreenState.Instructions, new Instructions(0, 0));
            ScreenManager.AddScreen(ScreenState.Stats, new GameStats(0, 0));
            ScreenManager.CurrentState = ScreenState.MainMenu;
        }

        public void Update() 
        {
            while (true)
            {
                ScreenManager.DrawCurrentScreen();
                ScreenManager.UpdateCurrentScreen();
            }
        }
    }
}
