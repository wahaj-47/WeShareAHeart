using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBase : MonoBehaviour
    {
        public bool finished { get; private set; }
        public bool skippable { get; private set; }

        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder)
        {
            skippable = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (i > 5) skippable = true;

                textHolder.text += input[i];
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));
            finished = true;
        }

        protected IEnumerator Skip(string input, TextMeshProUGUI textHolder)
        {
            textHolder.text = input;
            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));
            finished = true;
        }

    }
}

