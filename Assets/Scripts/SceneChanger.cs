    using UnityEngine;
    using UnityEngine.SceneManagement;
     
    public class SceneChanger : MonoBehaviour
    {
        public void Awake()
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        public void NextScene()
        {
            Debug.Log("Changing Scene...");
            SceneManager.LoadScene("Game");
        }
    }
