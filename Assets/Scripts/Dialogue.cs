using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Dialogue
{
    //This class loads all the XML info

    [XmlAttribute("id")]
    public int ID               { get; set; }

    [XmlElement("sourceNPC")]
    public string SourceNPC     { get; set; }

    [XmlElement("text")]
    public string Text          { get; set; }

    [XmlArray("options")]
    [XmlArrayItem("option")]
    public string[] Options     { get; set; }

    [XmlArray("targetnodes")]
    [XmlArrayItem("targetnode")]
    public int[] targetnodes    { get; set; }
}
