using Assets.Scripts.Common.Consts;
using SkyWorld.Player;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    public class Wing : MonoBehaviour {
        [SerializeField] private float _wingPower = 0.05f;
        private PlayerMovement playerMovement;

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