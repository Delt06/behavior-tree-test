using Modules.Mvvm.Views;
using TMPro;
using UnityEngine;

namespace Game.Characters
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