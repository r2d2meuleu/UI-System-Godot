using Godot;

namespace UISystem.Core.Extensions
{
    public static class Extensions
    {

        public static bool IsValid<T>(this T node) where T : GodotObject
        {
            return node != null
                && GodotObject.IsInstanceValid(node)
                && !node.IsQueuedForDeletion();
        }

        public static void SafeQueueFree(this Node node)
        {
            if (node.IsValid()) node.QueueFree();
        }

        public static void SetSizeAndPosition(this Control control, Vector2 size, Vector2 position)
        {
            control.Size = size;
            control.Position = position;
        }

        public static void HideItem(this CanvasItem item)
        {
            item.Modulate = new Color(item.Modulate, 0);
        }

        public static void ShowItem(this CanvasItem item)
        {
            item.Modulate = new Color(item.Modulate, 1);
        }

    }
}
