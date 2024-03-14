using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        StartCoroutine(creditsroll());
    }
    IEnumerator creditsroll()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("StartMenu");
    }

    // Update is called once per frame
}
