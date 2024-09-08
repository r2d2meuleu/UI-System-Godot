﻿using Godot;
using UISystem.Common.Elements;
using UISystem.Common.Interfaces;

namespace UISystem.MenuSystem.Views;
public partial class AudioSettingsMenuView : SettingsMenuView
{

    [Export] private HSliderView musicSlider;
    [Export] private HSliderView sfxSlider;
    [Export] private ButtonView saveSettingsButton;
    [Export] private ButtonView returnButton;

    public HSliderView MusicSlider => musicSlider;
    public HSliderView SfxSlider => sfxSlider;
    public ButtonView SaveSettingsButton => saveSettingsButton;
    public ButtonView ReturnButton => returnButton;

    protected override void PopulateFocusableElements()
    {
        _focusableElements = new IFocusableControl[] { MusicSlider, SfxSlider, SaveSettingsButton, ResetButton, ReturnButton };
    }

}