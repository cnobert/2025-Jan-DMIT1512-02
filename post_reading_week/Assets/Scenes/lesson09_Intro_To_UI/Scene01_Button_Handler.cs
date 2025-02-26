using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene01_Button_Handler : MonoBehaviour
{
    private void OnEnable()
    {
        //get the root of UI Element
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button changeToScene02Button = root.Q<Button>("ChangeToScene02Button");
        if(changeToScene02Button != null)
        {
            changeToScene02Button.clicked += ChangeToScene02;
        }
    }

    //VORSICHT!
    //Scene02 must be listed in File -> Build Profiles -> Scene List in Unity for the code below to work
    private void ChangeToScene02()
    {
        SceneManager.LoadScene("Scene02");
    }
}
