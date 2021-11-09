using BattlesSDK.Api;

namespace BattlesSDK
{
    internal class KeyPressInfo
    {
        public KeyCode key;
        public bool isKeyDown;
        public bool isKeyHeld;
        public bool isKeyUp;
        private bool wasKeyDown; // used to track whether or not key has gone through complete cycle of press->release

        public KeyPressInfo(KeyCode key)
        {
            this.key = key;
        }

        public void UpdateKeyInfo()
        {
            SetKeyDown();
            SetKeyHeld();
            SetKeyUp();
        }

        private void SetKeyDown()
        {
            isKeyDown = false;
            if (key.GetKey() && !wasKeyDown && !isKeyHeld)
            {
                isKeyDown = true;
                wasKeyDown = true;
            }
        }

        private void SetKeyHeld()
        {
            isKeyHeld = key.GetKey();
        }

        private void SetKeyUp()
        {
            isKeyUp = false;
            if (wasKeyDown && !key.GetKey())
            {
                isKeyUp = true;
                wasKeyDown = false;
            }
        }
    }
}
