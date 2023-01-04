using UnityEngine;
using TMPro;

namespace YIZU
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)] //�ڧѰORange�Φb��
        private float diaIntervalTime = 0.1f; //��ܶ��j�ɶ�
        [SerializeField, Header("�}�Y���")]
        private DialogueDeta diaOpening;
        
        private WaitForSeconds diaInterval => new WaitForSeconds(diaIntervalTime); //��ܥX�{?
        
        private CanvasGroup groupDialogue; //�t�θs��
        private TextMeshProUGUI textName; //��ܪ̦W��
        private TextMeshProUGUI textContent; //��ܤ��e
        private GameObject tri; //��ܹϥܡA�X�{�P�_��gameObject;

        private void Awake()
        {
            groupDialogue = GameObject.Find("�e����ܨt��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̦W��").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            tri = GameObject.Find("��ܮا����ϥ�");
            tri.SetActive(false);

        }
    }
}