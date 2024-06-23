using UnityEngine;
using UnityEngine.UIElements;

public class CustomButtonController : MonoBehaviour
{

    [SerializeField]
    private UIDocument _uiDocument;

    private Button _button;

    private void Start()
    {
        _button = _uiDocument.rootVisualElement.Q<Button>("button");

        _button?.RegisterCallback(
            (ClickEvent _, VisualElement _) => Debug.Log("Clicked"),
            _uiDocument.rootVisualElement);
    }

}
