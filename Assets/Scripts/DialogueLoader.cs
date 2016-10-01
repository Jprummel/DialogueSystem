using UnityEngine;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour {
    
    [Header("Load XML Dialogue File")]
    [SerializeField]private TextAsset   _diaFile;

    [Header("Text Objects")]
    [SerializeField]private Text    _sourceNPC;     //Npc thats talking
    [SerializeField]private Text    _dialogueSpeech;//The npc's dialogue

    private Dialogue                _currentDia;    //Current dialogue
    private DialogueOptionButtons   _diaButtons;    //Response buttons
    private DialogueContainer       _diaContainer;  //Create dialogue container

    void Start ()
    {
        _diaButtons = GetComponent<DialogueOptionButtons>();
        //Load all the data in the container
        _diaContainer = DialogueContainer.Load(_diaFile);
        //Load the dialogue's first node
        LoadDialogue(1);
	}

    public void CheckDialogue(int index)
    {
        LoadDialogue(_currentDia.targetnodes[index]);
    }

    public void LoadDialogue(int ID)
    {
        //Check for each dialogue in the container
        foreach (Dialogue dialogue in _diaContainer.diaList)
        {
            //Check if the ID is the same as one of the dialogue's ID
            if (dialogue.ID == ID)
            {
                GetDialogue(dialogue);
                                
                if (_currentDia.Options.Length > 0)
                {
                    _diaButtons.RemoveButtons();            //Removes buttons that arent used
                    _diaButtons.AddButtons(_currentDia);    // Adds buttons equal to the amount of responses/options to the current dialogue
                }
                else
                {
                    _diaButtons.RemoveButtons();
                }
            }
        }
    }

    void GetDialogue(Dialogue dialogue)
    {
        //sets the text for the current dialog and shows the name of the NPC talking
        _currentDia             = dialogue;
        _sourceNPC.text         = _currentDia.SourceNPC;
        _dialogueSpeech.text    = _currentDia.Text;
    }
}
