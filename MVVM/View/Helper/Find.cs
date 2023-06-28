using System.Windows;

namespace SpaceTradersApp.MVVM.View;

public static class Find
{
    /// <summary>
    /// Moves the Elementhierarchy upwards until it finds the frameworkelement of the specified name
    /// </summary>
    /// <param name="fwElement">The FrameworkElement to search</param>
    /// <param name="name">The Name of the element to find</param>
    /// <returns></returns>
    public static FrameworkElement? ParentElementByName(FrameworkElement? fwElement, string? name)
    {
        if (fwElement == null || name == null) return null;

        if (fwElement.Name == name) return fwElement;

        return ParentElementByName(fwElement.Parent as FrameworkElement, name);
    }
}