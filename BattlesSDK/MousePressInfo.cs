using BattlesSDK.Api;

namespace BattlesSDK
{
    internal class MousePressInfo
    {
        public Mouse button;
        public bool isButtonDown;
        public bool isButtonHeld;
        public bool isButtonUp;
        private bool wasButtonDown; // used to track whether or not Button has gone through complete cycle of press->release

        public MousePressInfo(Mouse button)
        {
            this.button = button;
        }

        public void UpdateButtonInfo()
        {
            SetButtonDown();
            SetButtonHeld();
            SetButtonUp();
        }

        private void SetButtonDown()
        {
            isButtonDown = false;
            if (button.GetButton() && !wasButtonDown && !isButtonHeld)
            {
                isButtonDown = true;
                wasButtonDown = true;
            }
        }

        private void SetButtonHeld()
        {
            isButtonHeld = button.GetButton();
        }

        private void SetButtonUp()
        {
            isButtonUp = false;
            if (wasButtonDown && !button.GetButton())
            {
                isButtonUp = true;
                wasButtonDown = false;
            }
        }
    }
}
