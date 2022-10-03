using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;

public class ScriptReader : MonoBehaviour
{
    [SerializeField]
    private TextAsset _InkJsonFile;
    private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;
    public Image characterIcon;

    [SerializeField]
    private GridLayoutGroup choiceHolder;
    [SerializeField]
    private Button choiceBasePrefab;

    [SerializeField]
    public LevelLoader loadNextScene;

    void Start()
    {
        LoadStory();
        _StoryScript.variablesState["FishCaught"] = ScoreManager.score;
        _StoryScript.variablesState["FishValue"] = ScoreManager.points;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            DisplayNextLine();
        }
    }

    void LoadStory() {
        _StoryScript = new Story(_InkJsonFile.text);

        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("Icon", (string charName) => CharacterIcon(charName));

    }

    public void DisplayNextLine() {
        if(_StoryScript.canContinue) {
            // Checking if there is content to go through
            string text = _StoryScript.Continue(); // Gets next line
            text = text?.Trim(); // Removes white space from the text
            dialogueBox.text = text;
        }
        else if (_StoryScript.currentChoices.Count > 0){
            DisplayChoices();
            //dialogueBox.text = "End";
        }
        else {
            loadNextScene.LoadNextScene(); // No more dialogue, move on to fishing
        }
    }

    private void DisplayChoices() {
        if(choiceHolder.GetComponentsInChildren<Button>().Length > 0) return;

        for(int i = 0; i < _StoryScript.currentChoices.Count; i++) {
            var choice = _StoryScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text); //creates a choice button

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text) {
        var choiceButton = Instantiate(choiceBasePrefab);
        choiceButton.transform.SetParent(choiceHolder.transform, false);

        // Change button prefab text
        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice) {
        _StoryScript.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
    }

    void RefreshChoiceView() {
        if(choiceHolder != null) {
            foreach(var button in choiceHolder.GetComponentsInChildren<Button>()) {
                Destroy(button.gameObject);
            }
        }
    }

    public void ChangeName(string name) {
        string SpeakerName = name;

        nameTag.text = SpeakerName;
    }

    public void CharacterIcon(string name) {
        var charIcon = Resources.Load<Sprite>("VNSprites/" + name);
        characterIcon.sprite = charIcon;
    }


}
