using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PLAYER : MonoBehaviour
{
    [SerializeField] private float speed; //Velocidade de Caminhada
    [SerializeField] private float runSpeed; //Velocidade de Corrida

    private Rigidbody2D rig; //Armazena informações da colisão

    private float initialSpeed; //Armazena o valor da velocidade incial
    private Vector2 direction; //Armazena um vetor x e y

    //Propriedades para acessar fora desse script
    public Vector2 prop_direction
    {
        get { return direction; }
        set { direction = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //Referencia a colisão
        initialSpeed = speed; //Atribui a velocidade de caminhada como a velocidade inicial
    }

    private void Update()
    {
        OnInput();
    }

    //Método que atualiza de forma fixa
    private void FixedUpdate()
    {
        OnMove();
    }

    void OnInput()
    {
        //Define a direção incrementando/decrementando o x caso aperte os botões horizontais, e a mesmca coisa com o y quando aperta os botões verticais
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   
    }
    void OnMove()
    {
        //Movimenta o personagem pegando a posição atual mais a direção multiplicado pela velocidade e pelo delta time
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime); 
    }
}
