using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueOptionButtons : MonoBehaviour {

    [SerializeField]private Button[] _options;       //The players response options

    public void AddButtons(Dialogue curDia)
    {
        for (int i = 0; i < curDia.Options.Length; i++)
        {
            _options[i].gameObject.SetActive(true);
            _options[i].gameObject.GetComponentInChildren<Text>().text = curDia.Options[i];
        }
    }

    public void RemoveButtons()
    {
        for (int i = 0; i < _options.Length; i++)
        {
            _options[i].gameObject.SetActive(false);
        }
    }
}
