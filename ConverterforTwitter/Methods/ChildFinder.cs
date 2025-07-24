using System.Windows;
using System.Windows.Media;

namespace HaruaConvert
{
    public static class ChildFinder
    {

        // ビジュアルツリーを探索して指定された型の要素を取得
        public static T FindVisualChild<T>(DependencyObject parent, string name = null) where T : DependencyObject
        {
            if (parent == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T target && (string.IsNullOrEmpty(name) || (child is FrameworkElement fe && fe.Name == name)))
                {
                    return target;
                }

                var result = FindVisualChild<T>(child, name);
                if (result != null) return result;
            }

            return null;
        }
    }
}

