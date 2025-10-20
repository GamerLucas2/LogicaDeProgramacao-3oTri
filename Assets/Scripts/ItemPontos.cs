using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPontos : MonoBehaviour
{
    [SerializeField] public int pontos = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(0);
        }
    }
}
