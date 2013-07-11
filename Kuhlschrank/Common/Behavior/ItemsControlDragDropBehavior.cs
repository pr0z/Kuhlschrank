using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Common.Behavior
{
    /// <summary>
    /// Classe qui décrit le comportement des tuiles composant le menu
    /// </summary>
    public class ItemsControlDragDropBehavior : Behavior<ItemsControl>
    {
        private bool _isMouseDown;
        private bool _isDragging;
        private Point _dragStartPosition;
        private UIElement _dragItem;
        private UIElement _dragContainer;
        private IDataObject _dataObject;
        private int _currentDropIndex;
        private Point _lastCheckPoint;

        protected override void OnAttached()
        {
            this.AssociatedObject.AllowDrop = true;
            this.AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
            this.AssociatedObject.PreviewMouseMove += AssociatedObject_PreviewMouseMove;
            this.AssociatedObject.PreviewDragOver += AssociatedObject_PreviewDragOver;
            this.AssociatedObject.PreviewDrop += AssociatedObject_PreviewDrop;
            this.AssociatedObject.PreviewMouseLeftButtonUp += AssociatedObject_PreviewMouseLeftButtonUp;

            base.OnAttached();
        }

        void AssociatedObject_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ItemsControl itemsControl = (ItemsControl)sender;
            Point p = e.GetPosition(itemsControl);

            object data = itemsControl.GetDataObjectFromPoint(p);
            _dataObject = data != null ? new DataObject(data.GetType(), data) : null;

            _dragContainer = itemsControl.GetItemContainerFromPoint(p);
            if (_dragContainer != null)
                _dragItem = GetItemFromContainer(_dragContainer);

            if (data != null)
            {
                _isMouseDown = true;
                _dragStartPosition = p;
            }
        }

        void AssociatedObject_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                ItemsControl itemsControl = (ItemsControl)sender;
                Point currentPosition = e.GetPosition(itemsControl);
                if ((_isDragging == false) && (Math.Abs(currentPosition.X - _dragStartPosition.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(currentPosition.Y - _dragStartPosition.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    DragStarted(e.GetPosition(itemsControl));
                }
                e.Handled = true;
            }
        }

        void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e)
        {
            UpdateDropIndex(e.GetPosition(this.AssociatedObject));
        }

        void AssociatedObject_PreviewDrop(object sender, DragEventArgs e)
        {
            UpdateDropIndex(e.GetPosition(this.AssociatedObject));
        }

        void AssociatedObject_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDown = false;
        }

        private void DragStarted(Point p)
        {
            if (!_isDragging)
            {
                _isDragging = true;

                if (_dragContainer != null)
                    _dragContainer.Opacity = 0.3;

                _currentDropIndex = FindDropIndex(p);

                DragDropEffects e = DragDrop.DoDragDrop(this.AssociatedObject, _dataObject, DragDropEffects.Copy | DragDropEffects.Move);

                ResetState();
            }
        }

        private void ResetState()
        {
            if (_dragContainer != null)
                _dragContainer.Opacity = 1.0;

            _isMouseDown = false;
            _isDragging = false;
            _dataObject = null;
            _dragItem = null;
            _dragContainer = null;
            _currentDropIndex = -1;
        }

        private void UpdateDropIndex(Point p)
        {
            if ((_lastCheckPoint - p).Length > SystemParameters.MinimumHorizontalDragDistance) // prevent too frequent call
            {
                int dropIndex = FindDropIndex(p);
                if (dropIndex != _currentDropIndex && dropIndex > -1)
                {
                    this.AssociatedObject.RemoveItem(_dataObject);
                    this.AssociatedObject.AddItem(_dataObject, dropIndex);
                    _currentDropIndex = dropIndex;
                }
                _lastCheckPoint = p;
            }
        }

        private int FindDropIndex(Point p)
        {
            ItemsControl itemsControl = this.AssociatedObject;
            UIElement dropTargetContainer = null;

            dropTargetContainer = itemsControl.GetItemContainerFromPoint(p);

            int index = -1;
            if (dropTargetContainer != null)
            {
                index = itemsControl.ItemContainerGenerator.IndexFromContainer(dropTargetContainer);

                if (!IsPointInTopHalf(p))
                    index = index++; // in second half of item, add after
            }
            else if (IsPointAfterAllItems(itemsControl, p))
            {
                // still within itemscontrol, but after all items
                index = itemsControl.Items.Count - 1;
            }

            return index;
        }

        public bool IsPointInTopHalf(Point p)
        {
            ItemsControl itemsControl = this.AssociatedObject;

            bool isInTopHalf = false;

            UIElement selectedItemContainer = itemsControl.GetItemContainerFromPoint(p);
            Point relativePosition = Mouse.GetPosition(selectedItemContainer);

            if (IsItemControlOrientationHorizontal())
                isInTopHalf = relativePosition.X < ((FrameworkElement)selectedItemContainer).ActualWidth / 2;
            else
                isInTopHalf = relativePosition.Y < ((FrameworkElement)selectedItemContainer).ActualHeight / 2;

            return isInTopHalf;
        }

        private bool IsItemControlOrientationHorizontal()
        {
            bool isHorizontal = false;
            Panel panel = GetItemsPanel();
            if (panel is WrapPanel)
                isHorizontal = ((WrapPanel)panel).Orientation == Orientation.Horizontal;
            else if (panel is StackPanel)
                isHorizontal = ((StackPanel)panel).Orientation == Orientation.Horizontal;

            return isHorizontal;
        }

        private UIElement GetItemFromContainer(UIElement container)
        {
            UIElement item = null;
            if (container != null)
                item = VisualTreeHelper.GetChild(container, 0) as UIElement;
            return item;
        }

        private Panel GetItemsPanel()
        {
            ItemsPresenter itemsPresenter = GetVisualChild<ItemsPresenter>(this.AssociatedObject);
            Panel itemsPanel = VisualTreeHelper.GetChild(itemsPresenter, 0) as Panel;
            return itemsPanel;
        }

        private static T GetVisualChild<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);

            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        private static bool IsPointAfterAllItems(ItemsControl itemsControl, Point point)
        {
            bool isAfter = false;

            UIElement target = itemsControl.GetLastItemContainer();
            Point targetPos = target.TransformToAncestor(itemsControl).Transform(new Point(0, 0));
            Point relativeToTarget = new Point(point.X - targetPos.X, point.Y - targetPos.Y);

            if (relativeToTarget.X >= 0 && relativeToTarget.Y >= 0)
            {
                var bounds = VisualTreeHelper.GetDescendantBounds(target);
                isAfter = !bounds.Contains(relativeToTarget);
            }
            return isAfter;
        }
    }

    public static class ItemsControlExtensions
    {
        public static object GetDataObjectFromPoint(this ItemsControl itemsControl, Point p)
        {
            UIElement element = itemsControl.InputHitTest(p) as UIElement;

            while (element != null)
            {
                if (element == itemsControl)
                    return null;

                object data = itemsControl.ItemContainerGenerator.ItemFromContainer(element);
                if (data != DependencyProperty.UnsetValue)
                    return data;
                else
                    element = VisualTreeHelper.GetParent(element) as UIElement;
            }
            return null;
        }

        public static UIElement GetItemContainerFromPoint(this ItemsControl itemsControl, Point p)
        {
            UIElement element = itemsControl.InputHitTest(p) as UIElement;

            while (element != null)
            {
                object data = itemsControl.ItemContainerGenerator.ItemFromContainer(element);

                if (data != DependencyProperty.UnsetValue)
                    return element;
                else
                    element = VisualTreeHelper.GetParent(element) as UIElement;
            }

            return element;
        }

        public static UIElement GetLastItemContainer(this ItemsControl itemsControl)
        {
            UIElement container = null;
            if (itemsControl.HasItems)
                container = itemsControl.GetItemContainerAtIndex(itemsControl.Items.Count - 1);

            return container;
        }

        public static UIElement GetItemContainerAtIndex(this ItemsControl itemsControl, int index)
        {
            UIElement container = null;

            if (itemsControl != null && itemsControl.Items.Count > index && itemsControl.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                container = itemsControl.ItemContainerGenerator.ContainerFromIndex(index) as UIElement;
            else
                container = itemsControl;

            return container;
        }

        public static void AddItem(this ItemsControl itemsControl, IDataObject item, int insertIndex)
        {
            if (itemsControl.ItemsSource != null)
            {
                foreach (string format in item.GetFormats())
                {
                    object data = item.GetData(format);
                    IList iList = itemsControl.ItemsSource as IList;
                    if (iList != null)
                        iList.Insert(insertIndex, data);
                    else
                    {
                        Type type = itemsControl.ItemsSource.GetType();
                        Type genericList = type.GetInterface("IList`1");
                        if (genericList != null)
                            type.GetMethod("Insert").Invoke(itemsControl.ItemsSource, new object[] { insertIndex, data });
                    }
                }
            }
            else
                itemsControl.Items.Insert(insertIndex, item);
        }

        public static void RemoveItem(this ItemsControl itemsControl, IDataObject itemToRemove)
        {
            if (itemToRemove != null)
            {
                foreach (string format in itemToRemove.GetFormats())
                {
                    object data = itemToRemove.GetData(format);
                    int index = itemsControl.Items.IndexOf(data);
                    if (index > -1)
                        itemsControl.RemoveItemAt(index);
                }
            }
        }

        public static void RemoveItemAt(this ItemsControl itemsControl, int removeIndex)
        {
            if (removeIndex != -1 && removeIndex < itemsControl.Items.Count)
            {
                if (itemsControl.ItemsSource != null)
                {
                    IList iList = itemsControl.ItemsSource as IList;
                    if (iList != null)
                    {
                        iList.RemoveAt(removeIndex);
                    }
                    else
                    {
                        Type type = itemsControl.ItemsSource.GetType();
                        Type genericList = type.GetInterface("IList`1");
                        if (genericList != null)
                            type.GetMethod("RemoveAt").Invoke(itemsControl.ItemsSource, new object[] { removeIndex });
                    }
                }
                else
                    itemsControl.Items.RemoveAt(removeIndex);
            }
        }
    }
}