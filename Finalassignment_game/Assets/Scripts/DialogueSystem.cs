using UnityEngine;
using TMPro;

namespace YIZU
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)] //我忘記Range用在哪
        private float diaIntervalTime = 0.1f; //對話間隔時間
        [SerializeField, Header("開頭對話")]
        private DialogueDeta diaOpening;
        
        private WaitForSeconds diaInterval => new WaitForSeconds(diaIntervalTime); //對話出現?
        
        private CanvasGroup groupDialogue; //系統群組
        private TextMeshProUGUI textName; //對話者名稱
        private TextMeshProUGUI textContent; //對話內容
        private GameObject tri; //對話圖示，出現與否用gameObject;

        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者名稱").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            tri = GameObject.Find("對話框完成圖示");
            tri.SetActive(false);

        }
    }
}