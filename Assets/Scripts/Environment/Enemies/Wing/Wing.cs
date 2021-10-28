using Assets.Scripts.Common.Consts;
using Assets.Scripts.Environment.Enemies.Spawner;
using SkyWorld.Player;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    public class Wing : MonoBehaviour, ISpawnedObjectBehaviour {
        [SerializeField] private float _wingPower = 0.05f;
        private PlayerMovement playerMovement;

        public void Init(ISpawnedObjectParametres parametres) {
            return;
            throw new System.NotImplementedException();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.gameObject.tag == Tags.PLAYER) {
                playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                playerMovement.WingInfluenceStart(_wingPower);
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if(collision.gameObject.tag == Tags.PLAYER) {
                playerMovement.WingInfluenceEnd();
            }
        }
    }
}