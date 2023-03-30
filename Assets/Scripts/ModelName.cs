using TMPro;
using UnityEngine;

namespace Game
{
    public class ModelName : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameSource;
        [SerializeField] private TMP_Text _nameDisplay;

        public void ApplyName()
        {
            _nameDisplay.text = _nameSource.text;
        }
    }
}
