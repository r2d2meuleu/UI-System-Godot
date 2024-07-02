﻿using UISystem.Common.Enums;
using UISystem.Constants;
using UISystem.MenuSystem.Interfaces;

namespace UISystem.MenuSystem.Models;
public class InterfaceSettingsMenuModel : IMenuModel
{

    private ControllerIconsType _tempIconsType;
    private readonly GameSettings _settings;

    public bool HasUnappliedSettings => ControllerIconsType != _tempIconsType;
    public ControllerIconsType ControllerIconsType { get => GameSettings.ControllerIconsType; set => _tempIconsType = value; }

    public InterfaceSettingsMenuModel(GameSettings settings)
    {
        _settings = settings;
        LoadSettings();
    }

    public void SelectIconType(int index)
    {
        _tempIconsType = (ControllerIconsType)index;
    }

    public void SaveSettings()
    {
        _settings.SetControllerIconsType(_tempIconsType);
        _settings.Save();
    }

    public void DiscardChanges()
    {
        _tempIconsType = ControllerIconsType;
    }

    public void ResetToDefault()
    {
        _tempIconsType = ConfigData.DefaultControllerIconsType;
        _settings.SetControllerIconsType(_tempIconsType);
        SaveSettings();
    }

    private void LoadSettings()
    {
        _tempIconsType = GameSettings.ControllerIconsType;
    }

}

