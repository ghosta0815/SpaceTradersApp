using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace SpaceTradersApp.MVVM.View
{
    /// <summary>
    /// The Property to attach to the SizeChanged event
    /// </summary>
    public class Observe : BaseAttachedProperty<Observe, bool>
    {
        /// <summary>
        /// Called when the property is changed, hooks into the SizeChanged Event
        /// </summary>
        /// <param name="sender">The <see cref="FrameworkElement"/> that this event is performed on</param>
        /// <param name="e">The Event arguments</param>
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;

            if ((bool)e.NewValue)
            {
                frameworkElement!.SizeChanged += OnFrameworkElementSizeChanged;
                UpdateObservedSizesForFrameworkElement(frameworkElement);
            }
            else
            {
                frameworkElement!.SizeChanged -= OnFrameworkElementSizeChanged;
            }
        }
        /// <summary>
        /// Event that updates the Size of the Observed Sizes
        /// </summary>
        /// <param name="sender">The <see cref="FrameworkElement"/> that this event is performed on</param>
        /// <param name="e">The Event arguments</param>
        private void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateObservedSizesForFrameworkElement(sender as FrameworkElement);
        }

        /// <summary>
        /// Updates the ObservableWidth and ObservableHeight Attached Property with
        /// the actual Width and Height of the <see cref="FrameworkElement"/>
        /// </summary>
        /// <param name="frameworkElement">The Element that we want to extract the size from</param>
        private void UpdateObservedSizesForFrameworkElement(FrameworkElement? frameworkElement)
        {
            frameworkElement.SetCurrentValue(ObservableWidth.ValueProperty, frameworkElement.ActualWidth);
            frameworkElement.SetCurrentValue(ObservableHeight.ValueProperty, frameworkElement.ActualHeight);
        }
    }

    /// <summary>
    /// The Width of a <see cref="Canvas"/> that can be observed
    /// </summary>
    public class ObservableWidth : BaseAttachedProperty<ObservableWidth, double> { }


    /// <summary>
    /// The Height of a <see cref="Canvas"/> that can be observed
    /// </summary>
    public class ObservableHeight : BaseAttachedProperty<ObservableHeight, double> { }


    /// <summary>
    /// If the Element is in Dragging Mode (mouse down)
    /// </summary>
    public class MouseClickObserve : BaseAttachedProperty<MouseClickObserve, bool>
    {
        /// <summary>
        /// Called when the property is changed, hooks into the SizeChanged Event
        /// </summary>
        /// <param name="sender">The <see cref="FrameworkElement"/> that this event is performed on</param>
        /// <param name="e">The Event arguments</param>
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;

            if ((bool)e.NewValue)
            {
                frameworkElement!.MouseLeftButtonDown += OnMouseDownChanged;
                frameworkElement.MouseLeftButtonUp += OnMouseUpChanged;
                //Enter and Leave frame
            }
            else
            {
                frameworkElement!.MouseLeftButtonDown -= OnMouseDownChanged;
                frameworkElement.MouseLeftButtonUp -= OnMouseUpChanged;
            }
        }

        /// <summary>
        /// Releases the mouse capture
        /// </summary>
        /// <param name="sender">The starscape</param>
        /// <param name="e">The mosue up event arguments</param>
        private void OnMouseUpChanged(object sender, MouseButtonEventArgs e)
        {
            var systemScape = sender as FrameworkElement;
            if (systemScape!.IsMouseCaptured) systemScape.ReleaseMouseCapture();
        }

        /// <summary>
        /// Captures the mouse on the starscape and saves its position"/>
        /// </summary>
        /// <param name="sender">The starscape</param>
        /// <param name="e">The mouse up event arguments</param>
        private void OnMouseDownChanged(object sender, MouseButtonEventArgs e)
        {
            Canvas? starScape = Find.ParentElementByName(sender as FrameworkElement, "StarScapeCanvas") as Canvas;
            if (starScape != null)
            {
                UpdateMouseDragStartPosition(starScape, Mouse.GetPosition(starScape));
            }
        }

        /// <summary>
        /// Updates the position of the mouse down Point on the StarScape
        /// </summary>
        /// <param name="point">The position where the mouse during the button press</param>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateMouseDragStartPosition(FrameworkElement frameworkElement, Point point)
        {
            frameworkElement.SetCurrentValue(MouseDragStartPosition.ValueProperty, point);
        }
    }

    /// <summary>
    /// The point where the left mouse button was pressed
    /// </summary>
    public class MouseDragStartPosition : BaseAttachedProperty<MouseDragStartPosition, Point> { }

}
