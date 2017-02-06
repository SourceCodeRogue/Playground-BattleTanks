using UnityEngine;

namespace Assets.Scripts
{
    public class GameDataStore
    {
        private static GameDataStore _instance = null;

        public static GameDataStore Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameDataStore();

                return _instance;
            }
        }

        public Vector2 CurrentPlayerDirection { get; set; }
        public float CurrentPlayerSpeed { get; set; }
    }
}
