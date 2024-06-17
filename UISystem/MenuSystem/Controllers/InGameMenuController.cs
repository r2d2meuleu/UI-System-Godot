﻿using Godot;
using UISystem.MenuSystem.Constants;
using UISystem.MenuSystem.Enums;
using UISystem.MenuSystem.Models;
using UISystem.MenuSystem.Views;

namespace UISystem.MenuSystem.Controllers;
public class InGameMenuController : MenuControllerFade<InGameMenuView, InGameMenuModel>
{

    public override MenuType MenuType => MenuType.InGame;

    public InGameMenuController(string prefab, InGameMenuModel model, MenusManager menusManager, SceneTree sceneTree) : base(prefab, model, menusManager, sceneTree)
    {

    }

    public override void HandleInputPressedWhenActive(InputEvent key)
    {
        base.HandleInputPressedWhenActive(key);

        if (key.IsPressed())
        {
            if (key.IsAction(InputsData.PauseButton))
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        _menusManager.ChangeMenu(MenuType.Pause, MenuStackBehaviourEnum.AddToStack);
    }

}