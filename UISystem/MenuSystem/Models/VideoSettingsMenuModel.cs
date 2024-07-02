﻿using Godot;
using UISystem.Constants;
using UISystem.MenuSystem.Interfaces;
using static Godot.DisplayServer;

namespace UISystem.MenuSystem.Models;
public class VideoSettingsMenuModel : IMenuModel
{

    private Vector2I _tempResolution;
    private WindowMode _tempWindowMode;
    private readonly GameSettings _settings;

    public int CurrentResolutionIndex { get; private set; }
    public int CurrenWindowModeIndex { get; private set; }
    public bool HasUnappliedSettings => Resolution != _tempResolution || WindowMode != _tempWindowMode;

    private Vector2I Resolution { get => GameSettings.Resolution; set => _tempResolution = value; }
    private WindowMode WindowMode { get => GameSettings.WindowMode; set => _tempWindowMode = value; }
    private static float Aspect => (float)ScreenGetSize().X / ScreenGetSize().Y;

    public VideoSettingsMenuModel(GameSettings settings)
    {
        _settings = settings;
        LoadSettings();
    }

    public void SelectWindowMode(int index)
    {
        _tempWindowMode = VideoSettings.WindowModeOptions[index];
        SetWindowMode(_tempWindowMode);
    }

    public void SelectResolution(int index)
    {
        _tempResolution = GetAvailableResolutions()[index];
        SetResolution(_tempResolution);
    }

    public string[] GetWindowModeOptionNames()
    {
        return VideoSettings.WindowModeNames;
    }

    public string[] GetAvailableResolutionNames()
    {
        return VideoSettings.GetResolutionsNamesForAspect(Aspect);
    }

    public void SaveSettings()
    {
        _settings.SetResolution(_tempResolution);
        _settings.SetWindowMode(_tempWindowMode);
        _settings.Save();
    }

    public void DiscardChanges()
    {
        _tempResolution = GameSettings.Resolution;
        _tempWindowMode = GameSettings.WindowMode;
        SetResolution(_tempResolution);
        SetWindowMode(_tempWindowMode);
    }

    public void ResetToDefault()
    {
        _tempResolution = ConfigData.DefaultResolution;
        _tempWindowMode = ConfigData.DefaultWindowMode;
        SaveSettings();
        SetResolution(_tempResolution);
        SetWindowMode(_tempWindowMode);
    }

    private static Vector2I[] GetAvailableResolutions()
    {
        return VideoSettings.GetResolutionsForAspect(Aspect);
    }

    private void LoadSettings()
    {
        _tempResolution = GameSettings.Resolution;
        _tempWindowMode = GameSettings.WindowMode;
        SetResolution(_tempResolution);
        SetWindowMode(_tempWindowMode);
    }

    private void SetResolution(Vector2I resolution)
    {
        CurrentResolutionIndex = VideoSettings.GetResolutionIndex(resolution, GetAvailableResolutions());
        WindowSetSize(resolution);
    }

    private void SetWindowMode(WindowMode mode)
    {
        CurrenWindowModeIndex = VideoSettings.GetWindwoModeIndex(mode);
        WindowSetMode(mode);

        // if you change resolution in fullscreen, then change window mode - window will not have the resolution that was selected
        // this is to prevent that
        if (mode == WindowMode.Windowed)
            WindowSetSize(_tempResolution);
    }

}
