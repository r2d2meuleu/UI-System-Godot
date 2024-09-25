﻿using Godot;
using UISystem.Common.Enums;

namespace UISystem.Common.Structs;
public readonly struct TweenSizeSettings
{

    public readonly Vector2 OriginalPosition = Vector2.Zero;
    public readonly Vector2 OriginalSize = Vector2.Zero;
    public readonly HorizontalControlSizeChangeDirection HorizontalDirection = HorizontalControlSizeChangeDirection.FromLeft;
    public readonly VerticalControlSizeChangeDirection VerticalDirection = VerticalControlSizeChangeDirection.FromTop;
    public readonly bool IsInitialized = false; // using it to not tween position when settings are default

    public TweenSizeSettings(Vector2 originalPosition, Vector2 originalSize,
        HorizontalControlSizeChangeDirection horizontalDirection,
        VerticalControlSizeChangeDirection verticalDirection)
    {
        OriginalPosition = originalPosition;
        OriginalSize = originalSize;
        HorizontalDirection = horizontalDirection;
        VerticalDirection = verticalDirection;
        IsInitialized = true;
    }

}