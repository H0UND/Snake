using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Models
{
    public class FirstLevelModel : LevelModel
    {
        public FirstLevelModel()
        {
            Level = 0;
            Name = "First";
            SunRotationX = 47f;
            SunRotationY = -30f;
            SunRotationZ = 0;
            SunColor = new Color(1f, 0.97f, 0.74f);
            PlayerSpeed = 7;
        }
    }
}