using TMPro;
using UnityEngine;

namespace YIZU
{
    //原本想測試回答但我太累
    public class DialogueChoice : MonoBehaviour
    {
        [SerializeField]
        private string[] sentences1;
        [SerializeField]
        public GameObject[] answers;

        public TextMeshProUGUI dialogText;

        void Start()
        {
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i].SetActive(true);
            }
        }

        void Update()
        {

        }

        public void DialogOption1()
        {
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i].SetActive(false);
            }
            dialogText.gameObject.SetActive(true);
            dialogText.text = (sentences1[0]);
        }
    }
}