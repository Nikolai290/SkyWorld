using Assets.Scripts.Common.Consts;
using Assets.Scripts.Environment.Enemies.Spawner;
using Assets.Scripts.Player.HealthSystem;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    public class Branch : MonoBehaviour, ISpawnedObjectBehaviour {

        [SerializeField] private int _damage;

        public void Init(ISpawnedObjectParametres parametres) {
            if(parametres is BranchParametres) {
                var param = (BranchParametres)parametres;
                _damage = param.damage;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == Tags.PLAYER) {
                try {
                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage);
                    Destroy(gameObject);
                } catch {
                    Debug.LogError("Player hasn't 'PlayerHealth' script!");
                }
                // TODO: add animation and sound effect
            }
        }
    }
}