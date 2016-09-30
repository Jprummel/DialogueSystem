using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogues")]
public class DialogueContainer
{
    [XmlArray("messages")]
    [XmlArrayItem("message")]
    public List<Dialogue> diaList = new List<Dialogue>();

    public static DialogueContainer Load(TextAsset file)
    {
        //Loads the file
        TextAsset _xml = file;

        //If there is no XML file, give an error
        if (_xml == null)
        {
            Debug.LogError("No XML file found!");
        }

        XmlSerializer serializer = new XmlSerializer(typeof(DialogueContainer));            //Create a serializer
        StringReader reader = new StringReader(_xml.text);                                  //Create a reader for the file
        DialogueContainer dialogues = serializer.Deserialize(reader) as DialogueContainer;  //Deserialize the XML file and put them in the dialogues
        reader.Close();//Close the file

        //Return the dialogues
        return dialogues;
    }
}
