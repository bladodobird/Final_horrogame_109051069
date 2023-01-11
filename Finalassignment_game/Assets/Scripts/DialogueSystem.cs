using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace YIZU
{
    /// <summary>
    /// ��ܨt��
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region ��ư�
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)] //�ڧѰORange�Φb��
        private float diaIntervalTime = 0.1f; //��ܶ��j�ɶ�
        [SerializeField, Header("�}�Y���")]
        private DialogueDeta diaOpening;
        [SerializeField, Header("��ܫ���")]
        private KeyCode dialogueKey = KeyCode.Space;

        private WaitForSeconds diaInterval => new WaitForSeconds(diaIntervalTime); //��ܥX�{?

        private CanvasGroup groupDialogue; //�t�θs��
        private TextMeshProUGUI textName; //��ܪ̦W��
        private TextMeshProUGUI textContent; //��ܤ��e
        private GameObject tri; //��ܹϥܡA�X�{�P�_��gameObject; 
        #endregion

        private PlayerInput playerInput;
        private UnityEvent onDiaFinish;

        private void Awake()
        {
            groupDialogue = GameObject.Find("�e����ܨt��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̦W��").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            tri = GameObject.Find("��ܮا����ϥ�");
            tri.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(diaOpening);

        }

        /// <summary>
        /// �}�l���
        /// </summary>
        /// <param name="deta"></param>
        /// <param name="_onDiaFinish"></param>
        public void StartDialogue(DialogueDeta deta, UnityEvent _onDiaFinish = null)
        {
            playerInput.enabled = false;
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(deta));
            onDiaFinish = _onDiaFinish;
        }

        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        private IEnumerator TypeEffect(DialogueDeta deta)
        {
            textName.text = deta.dialogueName;

            for (int j = 0; j < deta.dialogueContents.Length; j++)
            {
                textContent.text = "";
                tri.SetActive(false);

                string dialogue = deta.dialogueContents[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return diaInterval;
                }

                tri.SetActive(true);


                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("<color=#993300>���U���s</color>");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;

            onDiaFinish?.Invoke();
        }

    }
}