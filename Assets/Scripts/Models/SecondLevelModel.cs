using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Models
{
    public class SecondLevelModel : LevelModel
    {
        public SecondLevelModel()
        {
            Level = 1;
            Name = "Second";
            SunRotationX = 30f;
            SunRotationY = -30f;
            SunRotationZ = 0;
            SunColor = new Color(1f, 0.88f, 0.74f);
            PlayerSpeed = 10;
        }
    }
}