﻿using Godot;
using System.Collections.Generic;
using UISystem.Core.PopupSystem.Enums;
using UISystem.Core.PopupSystem.Interfaces;
using UISystem.PopupSystem.Constants;
using UISystem.PopupSystem.Controllers;

namespace UISystem.Core.PopupSystem;
public partial class PopupsManager
{

    public void Init()
    {
        SceneTree tree = GetTree();

        _controllers = new Dictionary<PopupType, IPopupController>();
        AddPopups(new IPopupController[]
        {
            new YesPopupController(GetPopupPath(PopupType.Yes), this, tree),
            new YesNoPopupController(GetPopupPath(PopupType.YesNo), this, tree),
            new YesNoCancelPopupController(GetPopupPath(PopupType.YesNoCancel), this, tree)
        });
    }

    private static string GetPopupPath(PopupType type)
    {
        return PopupViewsPaths.Paths[type];
    }

}
