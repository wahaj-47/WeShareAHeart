using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueSequence : MonoBehaviour
    {
        [Header("Delay")]
        [SerializeField] private float startDelay = 0;

        private void OnTriggerEnter2D()
        {
            GetComponent<Collider2D>().enabled = false;
            StateManager.instance.DisablePlayers();
            StartCoroutine(StartSequence());
        }

        public IEnumerator StartSequence()
        {
            yield return new WaitForSeconds(startDelay);

            for (int i=0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<Dialogue>().finished);
                transform.GetChild(i).gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
            StateManager.instance.EnablePlayers();
        }
    }
}

