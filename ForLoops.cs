
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class ForLoops : UdonSharpBehaviour
{
    public int numberOfLoops = 9;
    public Text textField;
    public void runLoops()
    {
        textField.text = "loops:";
        for(int i = 0; i < numberOfLoops; i++)
        {
            textField.text = string.Concat(textField.text, i.ToString());
        }
    }
}
