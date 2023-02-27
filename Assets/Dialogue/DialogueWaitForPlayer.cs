using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueWaitForPlayer : MonoBehaviour
{
    [YarnCommand("wait_player")]
    static IEnumerator CustomWait()
    {

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Because this method returns IEnumerator, it's a coroutine. 
        // Yarn Spinner will wait until onComplete is called.
    }
}
