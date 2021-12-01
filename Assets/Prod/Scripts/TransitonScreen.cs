using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitonScreen : MonoBehaviour
{
    public Animator transitionAnim;

    public int sceneId;

    public void ButtonLoadScene(int id)
    {
        sceneId = id;
        StartCoroutine(LoadScene());
    }
    
    public IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("changedScene");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneId);
    }
}
