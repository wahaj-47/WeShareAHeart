using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem
{
    public class DialogueSequence : MonoBehaviour
    {
        [Header("Delay")]
        [SerializeField] private float startDelay = 0;

        public UnityEvent onSequenceComplete;

        private void Start()
        {
            if (GameStateManager.instance.tutorialCompleted)
                gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D()
        {
            if (GameStateManager.instance.tutorialCompleted)
            {
                gameObject.SetActive(false);
                return;
            }
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
            if(onSequenceComplete != null)
                onSequenceComplete.Invoke();
            gameObject.SetActive(false);

            StateManager.instance.EnablePlayers();
        }
    }
}

