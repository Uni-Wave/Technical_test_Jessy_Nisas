using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Save_Show_Text : MonoBehaviour
{
    private void Start()
    {
        TextMeshProUGUI tmp = GetComponent<TextMeshProUGUI>();

        // If tmp == null, I'm in the scene1 else I show text 
        if (tmp != null)  
            tmp.text = PlayerPrefs.GetString("TextScene1");
        else
            PlayerPrefs.SetString("TextScene1", "");
    }
    public void SaveString(string text)
    {
        PlayerPrefs.SetString("TextScene1", text);
    }
}
