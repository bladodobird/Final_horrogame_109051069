using System.Collections;
using UnityEngine;

namespace YIZU
{

    public class Coroutine : MonoBehaviour
    {
        private string testDialogue = "ด๚ธี123";



        private void Awake()
        {
            StartCoroutine(ShowDialogueUseFor());
        }

        private IEnumerator ShowDialogueUseFor()
        {
            for (int i = 0; i < testDialogue.Length; i++)
            {
                print(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}