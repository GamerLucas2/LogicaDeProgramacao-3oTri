using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleTriangulo : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float velocidadeAngular = 30;
    [SerializeField] private TextMeshProUGUI score, vidaText;
    [SerializeField] private Image life;
    [SerializeField] private Sprite[] lifeSprites;

    private int pontos = 0;
    private int vida = 3;

    private float velY;

    InputSystem_Actions inputSystemActions; // <- Campo
    InputAction move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputSystemActions = new InputSystem_Actions();
        move = inputSystemActions.Player.Move;
        inputSystemActions.Enable();
        vidaText.text = "Vidas: " + vida;
    }

    private void OnDisable()
    {
        inputSystemActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sentido = move.ReadValue<Vector2>();
        // transform.Translate(0, sentido.y * velocidade *  Time.deltaTime, 0);
        velY = velocidade * sentido.y;
        transform.Rotate(0, 0, sentido.x * -velocidadeAngular * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D> ().linearVelocity = transform.up * velY;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            pontos++;
            score.text = pontos.ToString("Score: 0000");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            vida--;
            vidaText.text = "Vidas: " + vida;
            life.sprite = lifeSprites[vida];
            if (vida <= 0)
                SceneManager.LoadScene("GameOver");
        }
        
        // print("Enter");
        /*else
            Destroy(gameObject);*/
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        print("Exit");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Stay");
    }*/
}