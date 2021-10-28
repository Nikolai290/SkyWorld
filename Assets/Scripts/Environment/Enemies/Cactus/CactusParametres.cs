using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    [CreateAssetMenu(fileName = "CactusParametres", menuName = "SkyWorld/CactusParametres", order = 0)]
    public class CactusParametres : ScriptableObject {
        public float shootInterval;
        public float shootIntervalInRound;
        public int shootCount;

        public bool UpShoot;
        public bool LeftShoot;
        public bool RightShoot;

        public int spikeDamage;
        public float spikeSpeed;
        public float spikeLifetime;

        public List<GameObject> Spikes;
    }
}