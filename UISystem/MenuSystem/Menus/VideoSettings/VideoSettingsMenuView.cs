﻿using Godot;
using UISystem.Common.Elements;
using UISystem.Common.Interfaces;

namespace UISystem.MenuSystem.Views;
public partial class VideoSettingsMenuView : SettingsMenuView
{

    [Export] private OptionButtonView windowModeDropdown;
    [Export] private OptionButtonView resolutionDropdown;
    [Export] private ButtonView saveSettingsButton;
    [Export] private ButtonView returnButton;

    public OptionButtonView WindowModeDropdown => windowModeDropdown;
    public OptionButtonView ResolutionDropdown => resolutionDropdown;
    public ButtonView SaveSettingsButton => saveSettingsButton;
    public ButtonView ReturnButton => returnButton;

    protected override void PopulateFocusableElements()
    {
        _focusableElements = new IFocusableControl[] 
        { WindowModeDropdown, ResolutionDropdown, SaveSettingsButton, ResetButton, ReturnButton };
    }

}