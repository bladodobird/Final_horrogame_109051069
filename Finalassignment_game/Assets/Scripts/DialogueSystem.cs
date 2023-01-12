using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace YIZU
{
    /// <summary>
    /// 對話系統
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)] //我忘記Range用在哪
        private float diaIntervalTime = 0.1f; //對話間隔時間
        [SerializeField, Header("開頭對話")]
        private DialogueDeta diaOpening;
        [SerializeField, Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.Space;

        private WaitForSeconds diaInterval => new WaitForSeconds(diaIntervalTime); //對話出現?

        private CanvasGroup groupDialogue; //系統群組
        private TextMeshProUGUI textName; //對話者名稱
        private TextMeshProUGUI textContent; //對話內容
        private GameObject tri; //對話圖示，出現與否用gameObject; 
        #endregion

        private PlayerInput playerInput;
        private UnityEvent onDiaFinish;

        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者名稱").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            tri = GameObject.Find("對話框完成圖示");
            tri.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(diaOpening);

        }

        /// <summary>
        /// 開始對話
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

                print("<color=#993300>按下按鈕</color>");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;

            onDiaFinish?.Invoke();
        }

    }
}