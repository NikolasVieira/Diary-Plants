using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_INTERACTION_CONTROL : MonoBehaviour
{
    [System.Serializable] //Exibe no inspector
    public enum Idioma
    {
        ptbr,
        eng,
        spa
    }
    public Idioma language;

    [Header("Components")] //Separa as vari�veis no inspector
    public GameObject GO_InteractionObject; //Janela do Dialogo
    public Image IMG_ObjectSprite; //Imagem do Ator
    public Text TXT_Information; //Texto do Ator dentro do Canvas
    public Text TXT_ObjectName; //Nome do Ator

    [Header("Settings")] //Separa as vari�veis no inspector
    public float typingSpeed; //Velocidade que o texto vai aparecer em segundos
    //Vari�veis de controle
    public bool isShowing; //Janela esta vis�vel
    private int index; //Index que vai percorrer as palavras
    private Sprite[] SPR_ActorProfile; //Array com as imagens dos Atores
    private string[] ARRAY_STR_ActorName; //Array com os nomes dos Atores
    private string[] ARRAY_STR_Sentences; //Array com as senten�as dos Atores

    public static SCR_INTERACTION_CONTROL instance; //Instancia a classe para usar em outros scripts

    //M�todo chamado antes de todos os m�todos start
    private void Awake()
    {
        instance = this; //instancia antes de todos os m�todos start
    }
    //Faz o efeito de mostrar letra por letra na caixa de dialogo
    IEnumerator TypeSentence()
    {
        //Para cada Letra na Senten�a executa o c�digo
        foreach (char letter in ARRAY_STR_Sentences[index].ToCharArray())
        {
            TXT_Information.text += letter; //Adiciona uma letra ao campo texto do canvas
            yield return new WaitForSeconds(typingSpeed); //Define quanto tempo vai esperar para executar o foreach
        }
    }
    //Vai passar para a pr�xima senten�a
    public void NextSentence()
    {
        //Se a fala que esta na caixa estiver igual a senten�a, executa
        if(TXT_Information.text == ARRAY_STR_Sentences[index])
        {
            Debug.Log("index = " + index);
            Debug.Log("ARRAY_STR_Sentences = " + ARRAY_STR_Sentences.Length);
            Debug.Log("if = " + (index < ARRAY_STR_Sentences.Length - 1));
            // Se o index for menor que a quantidade de senten�as menos 1, executa
            if (index < ARRAY_STR_Sentences.Length - 1)
            {
                index++;
                Debug.Log("index novo = " + index);
                IMG_ObjectSprite.sprite = SPR_ActorProfile[index];
                TXT_ObjectName.text = ARRAY_STR_ActorName[index];
                TXT_Information.text = ""; //Apaga o texto para receber outro
                StartCoroutine(TypeSentence()); //chama o m�todo que coloca letra por letra
            }
            else // quando termina as senten�as
            {
                Debug.Log("TXT_ObjectName = " + TXT_ObjectName.text);
                TXT_ObjectName.text = ""; //Apaga o texto para receber outro
                Debug.Log("TXT_ObjectName novo = " + TXT_ObjectName.text);

                Debug.Log("TXT_Information = " + TXT_Information.text);
                TXT_Information.text = ""; //Apaga o texto para receber outro
                Debug.Log("TXT_Information novo = " + TXT_Information.text);

                index = 0; //Reinicia o index para come�ar o dialogo do inicio
                Debug.Log("index REINICIADO = " + index);

                Debug.Log("GO_InteractionObject = " + GO_InteractionObject.active);
                GO_InteractionObject.SetActive(false); //Desativa a caixa de dialogo
                Debug.Log("GO_InteractionObject novo = " + GO_InteractionObject.active);

                Debug.Log("ARRAY_STR_Sentences = " + ARRAY_STR_Sentences);
                ARRAY_STR_Sentences = null; //Apaga o hist�rico do dialogo para receber outro
                Debug.Log("ARRAY_STR_Sentences novo = " + ARRAY_STR_Sentences);

                Debug.Log("isShowing = " + isShowing);
                isShowing = false; //Define que a janela n�o esta sendo exibida
                Debug.Log("isShowing novo = " + isShowing);
            }
        }
    }
    //Vai passar para a senten�a anterior
    public void PreviousSentence()
    {
        //Se a fala que esta na caixa estiver igual a senten�a, executa
        if (TXT_Information.text == ARRAY_STR_Sentences[index])
        {
            Debug.Log("index = " + index);
            Debug.Log("ARRAY_STR_Sentences = " + ARRAY_STR_Sentences.Length);
            Debug.Log("if = " + (index < ARRAY_STR_Sentences.Length - 1));
            // Se o index for menor que a quantidade de senten�as menos 1, executa
            if (index <= ARRAY_STR_Sentences.Length - 1)
            {
                if (index != 0)
                {
                    index--;
                }
                Debug.Log("index novo = " + index);
                IMG_ObjectSprite.sprite = SPR_ActorProfile[index];
                TXT_ObjectName.text = ARRAY_STR_ActorName[index];
                TXT_Information.text = ""; //Apaga o texto para receber outro
                StartCoroutine(TypeSentence()); //chama o m�todo que coloca letra por letra
            }
            else // quando termina as senten�as
            {
                Debug.Log("TXT_ObjectName = " + TXT_ObjectName.text);
                TXT_ObjectName.text = ""; //Apaga o texto para receber outro
                Debug.Log("TXT_ObjectName novo = " + TXT_ObjectName.text);
                
                Debug.Log("TXT_Information = " + TXT_Information.text);
                TXT_Information.text = ""; //Apaga o texto para receber outro
                Debug.Log("TXT_Information novo = " + TXT_Information.text);

                index = 0; //Reinicia o index para come�ar o dialogo do inicio
                Debug.Log("index REINICIADO = " + index);

                Debug.Log("GO_InteractionObject = " + GO_InteractionObject.active);
                GO_InteractionObject.SetActive(false); //Desativa a caixa de dialogo
                Debug.Log("GO_InteractionObject novo = " + GO_InteractionObject.active);

                Debug.Log("ARRAY_STR_Sentences = " + ARRAY_STR_Sentences);
                ARRAY_STR_Sentences = null; //Apaga o hist�rico do dialogo para receber outro
                Debug.Log("ARRAY_STR_Sentences novo = " + ARRAY_STR_Sentences);

                Debug.Log("isShowing = " + isShowing);
                isShowing = false; //Define que a janela n�o esta sendo exibida
                Debug.Log("isShowing novo = " + isShowing);
            }
        }
    }
    //Vai mostrar o dialogo do Ator quando poss�vel
    public void Speech(string[] txt, string[] name, Sprite[] spriteNpc)
    {
        //Se n�o estiver mostrando a frase executa o c�digo
        if(!isShowing)
        {
            GO_InteractionObject.SetActive(true); //Define a janela do dialogo como ativa
            SPR_ActorProfile = spriteNpc; //Passa a lista de imagens para a lista que vai mostrar elas
            ARRAY_STR_ActorName = name; //Passa a lista de nomes para a lista que vai mostrar elas
            ARRAY_STR_Sentences = txt; //Passa a lista de palavras para a lista que vai mostrar elas
            
            IMG_ObjectSprite.sprite = SPR_ActorProfile[index];
            TXT_ObjectName.text = ARRAY_STR_ActorName[index];

            StartCoroutine(TypeSentence()); //Inicia a courotine que vai percorrer as letras das palavras
            isShowing = true; //Define que a janela esta sendo exibida
        }
    }
}
