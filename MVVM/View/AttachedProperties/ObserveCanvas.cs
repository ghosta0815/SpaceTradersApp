using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpaceTradersApp.MVVM.View.AttachedProperties
{
    public class ObserveCanvas : Canvas
    {
        #region Dependency Properties
        /// <summary>
        /// True, if the Height and Width of the Canvas shall be observable via Binding
        /// </summary>
        public static readonly DependencyProperty ObserveProperty = DependencyProperty.RegisterAttached(
            "Observe",
            typeof(bool),
            typeof(Canvas),
            new PropertyMetadata(default(bool), new PropertyChangedCallback(OnObserveChanged)));

        /// <summary>
        /// The Width of the canvas that can be bound
        /// </summary>
        public static readonly DependencyProperty ObservableWidthProperty = DependencyProperty.RegisterAttached(
            "ObservableWidth",
            typeof(double),
            typeof(Canvas),
            new PropertyMetadata(default(double)));

        /// <summary>
        /// The Height of the Canvas that can be bound
        /// </summary>
        public static readonly DependencyProperty ObservableHeightProperty = DependencyProperty.RegisterAttached(
            "ObservableHeight",
            typeof(double),
            typeof(Canvas),
            new PropertyMetadata(default(double)));
        #endregion

        #region getter/setter
        /// <summary>
        /// Sets if the Canvas height and width are observable
        /// </summary>
        /// <param name="d">The Calling Object</param>
        /// <param name="value">The value if it will be observable</param>
        public static void SetObserve(DependencyObject d, bool value)
        {
            d.SetValue(ObserveProperty, value);
        }

        /// <summary>
        /// Gets if the Canvas heigth and width are observable
        /// </summary>
        /// <param name="d">The Calling Object</param>
        /// <returns></returns>
        public static bool GetObserve(DependencyObject d)
        {
            return (bool)d.GetValue(ObserveProperty);
        }

        public static void SetObservableWidth(DependencyObject d, double value)
        {
            d.SetValue(ObservableWidthProperty, value);
        }

        public static double GetObservableWidth(DependencyObject d)
        {
            return (double)d.GetValue(ObservableWidthProperty);
        }

        public static void SetObservableHeight(DependencyObject d, double value)
        {
            d.SetValue(ObservableHeightProperty, value);
        }

        public static double GetObservablHeight(DependencyObject d)
        {
            return (double)d.GetValue(ObservableHeightProperty);
        }
        #endregion

        #region Events
        public static void OnObserveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canvas = d as Canvas;

            if((bool) e.NewValue)
            {
                canvas!.SizeChanged += OnCanvasSizeChanged;
                CanvasSizeChanged(canvas);

            } else
            {
                canvas!.SizeChanged -= OnCanvasSizeChanged;
            }
        }

        private static void OnCanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasSizeChanged((Canvas)sender);
        }

        private static void CanvasSizeChanged(Canvas canvas)
        {
            canvas.SetCurrentValue(ObservableWidthProperty, canvas.ActualWidth);
            canvas.SetCurrentValue(ObservableHeightProperty, canvas.ActualHeight);
        }
        #endregion
    }
}
