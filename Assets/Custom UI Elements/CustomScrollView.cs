using UnityEngine.UIElements;

namespace Custom_UI_Elements_Namespace
{

    public class CustomScrollView : ScrollView
    {

        public bool hideScrollbars { get; set; }

        private bool _isMouseDown;

        public CustomScrollView()
        {
            RegisterCallback<MouseDownEvent>(OnMouseDown);
            RegisterCallback<MouseMoveEvent>(OnMouseMove);
            RegisterCallback<MouseUpEvent>(OnMouseUp);
        }

        public new class UxmlFactory : UxmlFactory<CustomScrollView, UxmlTraits>
        {

        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {

            private readonly UxmlBoolAttributeDescription _hideScrollbars =
                new() { name = "hide-scrollbars", defaultValue = false };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                if (ve is not CustomScrollView customScrollView)
                {
                    return;
                }

                customScrollView.hideScrollbars = _hideScrollbars.GetValueFromBag(bag, cc);

                if (!customScrollView.hideScrollbars)
                {
                    return;
                }

                customScrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;
                customScrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            }

        }

        protected virtual void OnMouseDown(MouseDownEvent evt)
        {
            _isMouseDown = true;
        }

        protected virtual void OnMouseMove(MouseMoveEvent evt)
        {
            if (!_isMouseDown)
            {
                return;
            }

            scrollOffset -= evt.mouseDelta;
        }

        protected virtual void OnMouseUp(MouseUpEvent evt)
        {
            _isMouseDown = false;
        }

    }

}
