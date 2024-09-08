﻿using GodotExtensions;
using System;
using UISystem.Common;
using UISystem.Common.Enums;
using UISystem.MenuSystem.Enums;
using UISystem.MenuSystem.Models;
using UISystem.MenuSystem.Views;
using UISystem.PopupSystem;

namespace UISystem.MenuSystem.Controllers;
public class InterfaceSettingsMenuController : SettingsMenuController<InterfaceSettingsMenuView, InterfaceSettingsMenuModel>
{

    private readonly int _controllerIconsNumber;

    public override MenuType MenuType => MenuType.InterfaceSettings;


    public InterfaceSettingsMenuController(string prefab, InterfaceSettingsMenuModel model, MenusManager menusManager, PopupsManager popupsManager) : 
        base(prefab, model, menusManager, popupsManager)
    {
        _controllerIconsNumber = Enum.GetNames(typeof(ControllerIconsType)).Length;
    }

    protected override void SetupElements()
    {
        _view.ReturnButton.ButtonDown += OnReturnToPreviousMenuButtonDown;
        SetupControllerIconsDropdown();
        _view.SaveSettingsButton.ButtonDown += OnSaveSettingsButtonDown;
        _view.ResetButton.ButtonDown += OnResetToDefaultButtonDown;
        DefaultSelectedElement = _view.ControllerIconsDropdown;
    }

    private void OnSaveSettingsButtonDown()
    {
        _model.SaveSettings();
        _lastSelectedElement = _view.SaveSettingsButton;
    }

    private void SetupControllerIconsDropdown()
    {
        OptionButtonItem[] items = new OptionButtonItem[_controllerIconsNumber];
        for (int i = 0; i < items.Length; i++)
        {
            var name = ((ControllerIconsType)i).ToString();
            items[i] = new OptionButtonItem(name, i);
        }
        _view.ControllerIconsDropdown.AddMultipleItems(items);
        _view.ControllerIconsDropdown.ItemSelected += SelectControllerIconsType;
        _view.ControllerIconsDropdown.Select((int)_model.ControllerIconsType);
    }

    private void SelectControllerIconsType(long index)
    {
        _model.SelectIconType((int)index);
        _lastSelectedElement = _view.ControllerIconsDropdown;
    }

    protected override void ResetViewToDefault()
    {
        _view.ControllerIconsDropdown.Select((int)_model.ControllerIconsType);
    }
}