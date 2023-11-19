using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PLAYER_ANIMATION : MonoBehaviour
{
    private SCR_PLAYER player; //Variável que pode armazenar conteudos do Script Player
    private Animator anim; //Variável que pode armazenar conteudos do Animator

    void Start()
    {
        player = GetComponent<SCR_PLAYER>(); //Recebe o componente do Script Player
        anim = GetComponent<Animator>(); //Recebe o componente do Animator
    }

    void Update()
    {
        switch (true)
        {
            //Se o X for maior que 0 (Objeto se movendo para a direita)
            case true when (player.prop_direction.x > 0):
                anim.SetInteger("param_transition", 2);
                anim.SetFloat("moveX", 1);
                anim.SetFloat("moveY", 0);
                break;
            //Se o X for menor que 0 (Objeto se movendo para a esquerda)
            case true when (player.prop_direction.x < 0):
                anim.SetInteger("param_transition", 4);
                anim.SetFloat("moveX", -1);
                anim.SetFloat("moveY", 0);
                break;
            //Se o Y for maior que 0 (Objeto se movendo para cima)
            case true when (player.prop_direction.y > 0):
                anim.SetInteger("param_transition", 1);
                anim.SetFloat("moveX", 0);
                anim.SetFloat("moveY", 1);
                break;
            //Se o Y for menor que 0 (Objeto se movendo para baixo)
            case true when (player.prop_direction.y < 0):
                anim.SetInteger("param_transition", 3);
                anim.SetFloat("moveX", 0);
                anim.SetFloat("moveY", -1);
                break;
            //Caso contrario está parado
            default:
                anim.SetInteger("param_transition", 0);
                break;
        }
        
        
    }
}
