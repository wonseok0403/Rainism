using System;
namespace Rainism.Models
{
    public class GameStatus
    {
        public GameStatus(){
        }
        public bool Online { get; set; }
        public bool IsReady { get; set; }
        public long RecentReadyTime { get; set; }
        public static int ReadyPeople { get; set; }
        public static int GamingPeople { get; set; }
        public long Id;
        public void GameReady(){
            ReadyPeople++;
            IsReady = true;
            RecentReadyTime = DateTime.Now.Ticks;
            Online = true;
        }
        public void GameStop(){
            ReadyPeople--;
            IsReady = false;
            Online = false;
        }
    }
}
