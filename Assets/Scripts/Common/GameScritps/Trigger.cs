using System;
using UnityEngine;

namespace Assets.Scripts.Common.GameScritps {
    public class Trigger : MonoBehaviour {

        public Action<GameObject> OnTriggerEnterAction;
        public Action<GameObject> OnTriggerStayAction;
        public Action<GameObject> OnTriggerExitAction;
        public string targetTag;

        public void Init(string tag,
            Action<GameObject> onTriggerEnterAction = null,
            Action<GameObject> onTriggerExitAction = null,
            Action<GameObject> onTriggerStayAction = null
        ) {
            this.OnTriggerEnterAction += onTriggerEnterAction;
            this.OnTriggerStayAction += onTriggerExitAction;
            this.OnTriggerExitAction += onTriggerStayAction;
            targetTag = tag;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == targetTag) {
                OnTriggerEnterAction?.Invoke(collision.gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D collision) {
            if (collision.gameObject.tag == targetTag) {
                OnTriggerStayAction?.Invoke(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.gameObject.tag == targetTag) {
                OnTriggerExitAction?.Invoke(collision.gameObject);
            }
        }

        private void OnDisable() {
            OnTriggerEnterAction = null;
            OnTriggerExitAction = null;
            OnTriggerStayAction = null;
        }
    }
}