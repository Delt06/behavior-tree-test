using Mvvm;
using TMPro;
using UnityEngine;

namespace Characters
{
    public class CharacterResourceView : ViewBase<CharacterResourceViewModel>
    {
        [SerializeField] private TMP_Text _text;

        protected override void Bind(CharacterResourceViewModel viewModel)
        {
            this.BindText(_text, viewModel.Resources);
        }
    }
}