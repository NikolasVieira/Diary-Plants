using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_INTERACTION_PLANT : MonoBehaviour
{
    public float dialogueRange; //Define o alcance que o diálogo pode ser ativado 
    public LayerMask targetLayer; //Define qual a layer que vai ativar o diálogo
    public SCR_INTERACTION scr_interaction; //Importa a classe de outro script para uma variavel
    bool targetHit; //Controla se algum objeto entrou na area do dialogo

    [Header("Diary Informations")]


    //Listas
    private List<string> sentences = new List<string>(); //Armazena as sentenças em uma lista
    private List<string> actorName = new List<string>(); //Armazena os nomes dos atores em uma lista
    private List<Sprite> actorSprite = new List<Sprite>(); //Armazena a imagem dos atores em uma lista

    private void Start()
    {
        GetPlantInfo();
    }

    private void Update()
    {
        // Se apertar a tecla E e ter algum objeto da layer alvo no alcance de diálogo
        if (Input.GetKeyDown(KeyCode.E) && targetHit)
        {
            //armazena no método speech a lista de sentenças em forma de array
            SCR_INTERACTION_CONTROL.instance.Speech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());
        }
    }

    //Método que recebe cada texto de cada caixa de dialogo
    void GetPlantInfo()
    {
        //Executa para cada numero de caixas de dialogos
        for(int i = 0; i < scr_interaction.informations.Count; i++)
        {
            actorSprite.Add(scr_interaction.informations[i].profile);
            actorName.Add(scr_interaction.informations[i].actorName);

            //Muda a frase dependendo da linguagem
            switch (SCR_INTERACTION_CONTROL.instance.language)
            {
                case SCR_INTERACTION_CONTROL.Idioma.ptbr:
                    //Adiciona a Lista de Sentenças as sentenças em português da classe scr_interaction
                    sentences.Add(scr_interaction.informations[i].sentenceLanguage.portuguese);
                    break;
                case SCR_INTERACTION_CONTROL.Idioma.eng:
                    //Adiciona a Lista de Sentenças as sentenças em inglês da classe scr_interaction
                    sentences.Add(scr_interaction.informations[i].sentenceLanguage.english);
                    break;
                case SCR_INTERACTION_CONTROL.Idioma.spa:
                    //Adiciona a Lista de Sentenças as sentenças em espanhol da classe scr_interaction
                    sentences.Add(scr_interaction.informations[i].sentenceLanguage.spanish);
                    break;
            } 
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();//Chama o método a todo momento
    }

    void ShowDialogue()
    {
        //cria um colisor usando a posição, tamanho e a layer que vai ativar o colisor
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, targetLayer); 
        // Se qualquer objeto da layer alvo esta na área de colisão executa
        if(hit != null)
        {
            targetHit = true;
        }
        else
        {
            targetHit = false;
        }
    }
    //Método que desenha um Gizmo
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
