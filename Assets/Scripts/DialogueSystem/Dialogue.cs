using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class Dialogue : DialogueBase
    {
        [Header("Inputs")]
        [SerializeField] private string dialogue;
        [SerializeField] private Sprite characterSprite;

        [Header("Components")]
        [SerializeField] private TextMeshProUGUI textHolder;
        [SerializeField] private Image imageHolder;

        private Coroutine coroutine;

        private void Awake()
        {
            textHolder.text = "";
            imageHolder.sprite = characterSprite;
        }

        private void Start()
        {
            coroutine = StartCoroutine(WriteText(dialogue, textHolder));
        }

        private void Update()
        {
            if (Input.GetButtonUp("Jump") && skippable)
            {
                StopCoroutine(coroutine);
                StartCoroutine(Skip(dialogue, textHolder));
            }
        }
    }
}
