using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ToolKit.Wccl.CustomPanel
{
    public partial class RowsPanel : Panel, IScrollInfo
    {
		public static readonly DependencyProperty RowHeightProperty = DependencyProperty.Register(
					"RowHeight",
					typeof(double),
					typeof(RowsPanel),
					new PropertyMetadata(30.0D));

		public bool AnimateScroll { get; set; }
		public RowsPanel()
		{
			// For use in the IScrollInfo implementation
			_trans = new TranslateTransform();
			this.RenderTransform = _trans;
		}

		public double RowHeight
		{
			get { return (double)GetValue(RowHeightProperty); }
			set { SetValue(RowHeightProperty, value); }
		}
		/// <summary>
		/// Measure the children
		/// </summary>
		/// <param name="constraint">Size available</param>
		/// <returns>Size desired</returns>
		protected override Size MeasureOverride(Size constraint)
		{
			if (constraint.Width == double.PositiveInfinity || constraint.Height == double.PositiveInfinity)
				return Size.Empty;
			UpdateScrollInfo(constraint);

			int childCount = InternalChildren.Count;
			for (int i = 0; i < childCount; i++)
			{
				InternalChildren[i].Measure(new Size(constraint.Width, RowHeight));
			}

			return constraint;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			UpdateScrollInfo(finalSize);

			int childCount = InternalChildren.Count;
			for (int i = 0; i < childCount; i++)
			{
				UIElement child = InternalChildren[i];

				child.Arrange(new Rect(0, i * RowHeight, finalSize.Width, RowHeight));
			}

			return finalSize;
		}

		private void UpdateScrollInfo(Size availableSize)
		{
			// See how many items there are
			int itemCount = InternalChildren.Count;
			bool viewportChanged = false;
			bool extentChanged = false;

			Size extent = CalculateExtent(availableSize, itemCount);
			// Update extent
			if (extent != _extent)
			{
				_extent = extent;
				extentChanged = true;
			}

			// Update viewport
			if (availableSize != _viewport)
			{
				_viewport = availableSize;
				viewportChanged = true;
			}

			if ((extentChanged || viewportChanged) && _scrollOwner != null)
			{
				_offset.Y = CalculateVerticalOffset(VerticalOffset);
				_offset.X = CalculateHorizontalOffset(HorizontalOffset);
				_scrollOwner.InvalidateScrollInfo();

				Scroll(HorizontalOffset, VerticalOffset);
			}
		}

		private Size CalculateExtent(Size availableSize, int itemCount)
		{
			return new Size(availableSize.Width, RowHeight * itemCount);
		}
	}
}
