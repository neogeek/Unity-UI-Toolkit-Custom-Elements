using UnityEngine.UIElements;

namespace Custom_UI_Elements_Namespace
{

    public class CustomButton : Button
    {

        public new class UxmlFactory : UxmlFactory<CustomButton, UxmlTraits>
        {

        }

    }

}
