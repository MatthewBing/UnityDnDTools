using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InitiativeTracker : MonoBehaviour {
    public Text InitiativeList;
    public Button AddCharacterButton;
    public Button DeleteCharacterButton;
    public InputField CharacterName;
    public InputField IndexOfCharacter;
    public Color HighlightColor;
    List<string> charstotrack = new List<string>();

    private void updateGUI() {
        InitiativeList.text = "";
        foreach (string Char in charstotrack) {
            InitiativeList.text += Char;
            InitiativeList.text += "\n";
        }
        CharacterName.text = null;
        IndexOfCharacter.text = null;
    }

    private void addchar(string charName, string index = null) {
        if (index == "") 
            charstotrack.Add(charName);
        else {
            int tempid;
            int.TryParse(index, out tempid);
            charstotrack.Insert(tempid, charName);
        }
        updateGUI();
    }

    private void delchar(string id) {
        int tempid;
        int.TryParse(id, out tempid);
        charstotrack.RemoveAt(tempid);
        updateGUI();
    }

    private void tickTurn() {
        Debug.Log(InitiativeList.text);
    }

    private void Awake() {
        if (InitiativeList == null || AddCharacterButton == null || DeleteCharacterButton == null ||
            CharacterName == null || IndexOfCharacter == null)
            Debug.Log("Not all GUI elemnts are set!");
        AddCharacterButton.onClick.AddListener(delegate{addchar(CharacterName.text, IndexOfCharacter.text); });
        DeleteCharacterButton.onClick.AddListener(delegate{delchar(IndexOfCharacter.text);});
    }

    private void Update() {
        if (EventSystem.current.currentSelectedGameObject == null) {
            if (Input.GetKeyDown(KeyCode.Space))
                tickTurn();
        }
    }
}
