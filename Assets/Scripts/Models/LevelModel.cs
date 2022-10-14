using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Models
{
    public class LevelModel
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public float SunRotationX { get; set; }
        public float SunRotationY { get; set; }
        public float SunRotationZ { get; set; }
        public Color SunColor { get; set; }
        public float PlayerSpeed { get; set; }
    }
}