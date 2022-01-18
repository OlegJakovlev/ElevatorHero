using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Option : MonoBehaviour
    {
        [SerializeField] protected Image _image;
        [SerializeField] protected Text _textComponent;

        [SerializeField] protected bool _defaultIsSet;
        public bool IsActive
        {
            get => IsSet;
            set
            {
                // Animation using coroutines
                if (value) InvokeRepeating(nameof(ToggleImage), 0, 0.5f);
                else
                {
                    CancelInvoke();
                    ResetImageState();
                }

                IsSet = value;
            }
        }
        protected bool IsSet = false;

        protected virtual void ResetImageState()
        {
            _image.enabled = _defaultIsSet;
        }

        protected virtual void ToggleImage()
        {
            _image.enabled = !_image.enabled;
        }
    }
}