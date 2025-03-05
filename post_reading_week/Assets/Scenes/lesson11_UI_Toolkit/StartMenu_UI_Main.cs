using UnityEngine;
using UnityEngine.UIElements;

public class StartMenu_UI_Main : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        if(root == null)
        {
            Debug.Log("UI Document not found!");
        }
        else
        {
            root.Q<Button>("StartGameButton").clicked += this.StartGame;
            root.Q<Button>("OptionsButton").clicked += this.OpenOptions;
            root.Q<Button>("QuitButton").clicked += this.QuitGame;
        }
    }
    private void StartGame()
    {
        Debug.Log("Starting Game...");
    }
    private void OpenOptions()
    {
        Debug.Log("Opening Options...");
    }
    private void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }
}
