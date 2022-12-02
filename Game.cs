using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.Threading;

namespace CustomProgram
{
    public class Game
    {
        public enum GameState
        {
            Start,
            StartTutorial,
            Tutorial,
            OnGoing,
            Pause,
            Lose,
            Win,
        }
        private GameState _state;
        public GameState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public void KeyHandle()
        {
            if (State == GameState.Start)
            {
                if (SplashKit.KeyTyped(KeyCode.UpKey) || SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    State = GameState.StartTutorial;
                }
                if (SplashKit.KeyTyped(KeyCode.FKey))
                {
                    State = GameState.OnGoing;
                }
            }
            else if (State == GameState.StartTutorial)
            {
                if (SplashKit.KeyTyped(KeyCode.UpKey) || SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    State = GameState.Start;
                }
                if (SplashKit.KeyTyped(KeyCode.FKey))
                {
                    State = GameState.Tutorial;
                }
            }
            else if (State == GameState.Tutorial)
            {
                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    State = GameState.StartTutorial;
                }
            }
            else if (State == GameState.OnGoing)
            {
                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    State = GameState.Pause;                 
                }
            }
            else if (State == GameState.Pause)
            {
                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    State = GameState.OnGoing;
                }
            }
        }

        public void Draw()
        {
            Bitmap bitmap;
            DrawingOptions opt;
            if (State == GameState.Start)
            {   
                opt = SplashKit.OptionScaleBmp(1.20, 1.32);
                bitmap = SplashKit.LoadBitmap("StartImage", "op1.png");
                SplashKit.DrawBitmap(bitmap, 23, 23, opt);
            }
            else if (State == GameState.StartTutorial)
            {
                opt = SplashKit.OptionScaleBmp(1.20, 1.32);
                bitmap = SplashKit.LoadBitmap("StartTutorial", "op2.png");
                SplashKit.DrawBitmap(bitmap, 23, 23, opt);
            }
            else if (State == GameState.Tutorial)
            {
                opt = SplashKit.OptionScaleBmp(0.6, 0.542);
                bitmap = SplashKit.LoadBitmap("Tutorial", "tutorial.png");
                SplashKit.DrawBitmap(bitmap, -105,-122, opt);
            }
            else if (State == GameState.Pause)
            {
                opt = SplashKit.OptionDefaults();
                bitmap = SplashKit.LoadBitmap("Pause", "paused.png");
                SplashKit.DrawBitmap(bitmap, 114.5, 113.5, opt);
            }
            else if (State == GameState.Lose)
            {
                opt = SplashKit.OptionScaleBmp(0.376, 0.328);
                bitmap = SplashKit.LoadBitmap("Lose", "GameOver.png");
                SplashKit.DrawBitmap(bitmap, -251.5, -244, opt);
            }
            else
            {
                opt = SplashKit.OptionScaleBmp(19 / 16, 1);
                bitmap = SplashKit.LoadBitmap("Win", "YouWin.jpg");
                SplashKit.DrawBitmap(bitmap, 20, 0, opt);
            }
            
        }

    }
}
