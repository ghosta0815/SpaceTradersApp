using System;
using System.Windows;

namespace SpaceTradersApp.MVVM.View;
    /// <summary>
    /// A base attached property to replace the vanilla WPF attached Property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be the attached property</typeparam>
    /// <typeparam name="Property">The type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
{
    #region public Properties
    /// <summary>
    /// A singleton instance of our parent class
    /// </summary>
    public static Parent Instance { get; private set; } = new Parent();

    #endregion

    #region Attached Property Definitions
    /// <summary>
    /// The attached propery for this class
    /// </summary>
    public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

    /// <summary>
    /// The callback event when the <see cref="ValueProperty"/> is changed
    /// </summary>
    /// <param name="d">The UI Element that had its property changed</param>
    /// <param name="e">The argument for the event</param>
    private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //Call the parent function
        Instance.OnValueChanged(d, e);

        //Call event listeners
        Instance.ValueChanged(d, e);
    }

    /// <summary>
    /// Gets the attached property
    /// </summary>
    /// <param name="d">The element to get the property from</param>
    /// <returns></returns>
    public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

    /// <summary>
    /// Sets the attached property
    /// </summary>
    /// <param name="d">The element to set the value on</param>
    /// <param name="value">The value to set to</param>
    public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);
    #endregion


    #region public Events

    public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

    #endregion

    #region Event Methods

    /// <summary>
    /// The Method that is called when any attached property of this type is changed
    /// </summary>
    /// <param name="sender">The UI element that this property was changed for</param>
    /// <param name="e">The arguments for this event</param>
    public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
    #endregion

}

