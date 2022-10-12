using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Models
{
    public class ThirdLevelModel : LevelModel
    {
        public ThirdLevelModel()
        {
            Level = 2;
            Name = "Third";
            SunRotationX = 10f;
            SunRotationY = -30f;
            SunRotationZ = 0;
            SunColor = new Color(1f, 0.64f, 0.58f);
            PlayerSpeed = 13;
        }
    }
}