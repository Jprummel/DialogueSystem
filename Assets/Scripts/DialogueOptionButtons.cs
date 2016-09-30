using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueOptionButtons : MonoBehaviour {

    [SerializeField]private Button[] _options;  //The players response options

    public void AddButtons(Dialogue curDia)
    {
        //Adds buttons for every available option/response to the current dialogue node
        for (int i = 0; i < curDia.Options.Length; i++)
        {
            _options[i].gameObject.SetActive(true);
            _options[i].gameObject.GetComponentInChildren<Text>().text = curDia.Options[i];
        }
    }

    public void RemoveButtons()
    {
        //Removes unused buttons
        for (int i = 0; i < _options.Length; i++)
        {
            _options[i].gameObject.SetActive(false);
        }
    }
}
