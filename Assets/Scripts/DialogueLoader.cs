using UnityEngine;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour {
    
    [Header("Load Dialogue File")]
    [SerializeField]private TextAsset   _diaFile;

    [Header("Text Objects")]
    [SerializeField]private Text        _sourceNPC;     //Npc thats talking
    [SerializeField]private Text        _speech;        //The npc's dialogue
    //[SerializeField]private Button[]    _options;       //The players response options


    private Dialogue                _currentDia;    //Current dialogue
    private DialogueOptionButtons   _diaButtons;    //response buttons
    //Create dialogue container
    private DialogueContainer       _diaContainer;

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
                    _diaButtons.RemoveButtons();                //Removes buttons that arent used
                    _diaButtons.AddButtons(_currentDia);   // Adds buttons equal to the amount of responses/options to the current dialogue
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
        _currentDialogue    = dialogue;
        _sourceNPC.text     = _currentDialogue.SourceNPC;
        _speech.text        = _currentDialogue.Text;
    }
}
