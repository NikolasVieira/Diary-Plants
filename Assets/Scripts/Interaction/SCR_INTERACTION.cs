using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Permite ao clicar com o botão direito nos assets, criar um objeto
[CreateAssetMenu(fileName = "New Interaction", menuName = "Scriptable Objects/Interaction")]

public class SCR_INTERACTION : ScriptableObject
{
    [Header("Interaction")]
    public Sprite objectSprite; //Imagem do Ator
    public string description; //Sentença do Ator

    public List<Descriptions> informations = new List<Descriptions>();
}

[System.Serializable]
public class Descriptions
{
    public string actorName; //Nome do Ator
    public Sprite profile; //Imagem do rosto do Ator
    public Languages sentenceLanguage; //Idioma da Sentença
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(SCR_INTERACTION))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SCR_INTERACTION dialogue_settings = (SCR_INTERACTION)target;

        Languages language_settings = new Languages();
        language_settings.portuguese = dialogue_settings.description;

        Descriptions sentences_settings = new Descriptions();
        sentences_settings.profile = dialogue_settings.objectSprite;
        sentences_settings.sentenceLanguage = language_settings;

        if(GUILayout.Button("Create Interaction"))
        {
            if(dialogue_settings.description != "")
            {
                dialogue_settings.informations.Add(sentences_settings);
                dialogue_settings.objectSprite = null;
                dialogue_settings.description = "";
            }
        }
    }
}
#endif
