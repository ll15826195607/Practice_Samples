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
        private TranslateTransform _trans = new TranslateTransform();
        private ScrollViewer _scrollOwner;
        private bool _canHScroll = false;
        private bool _canVScroll = false;
        private Size _extent = new Size(0, 0);
        private Size _viewport = new Size(0, 0);
        private Point _offset;
        public bool CanVerticallyScroll { get => _canVScroll; set => _canVScroll = value; }
        public bool CanHorizontallyScroll { get => _canHScroll; set => _canHScroll = value; }

        public double ExtentWidth => _extent.Width;

        public double ExtentHeight => _extent.Height;

        public double ViewportWidth => _viewport.Width;

        public double ViewportHeight => _viewport.Height;

        public double HorizontalOffset => _offset.X;

        public double VerticalOffset => _offset.Y;

        public ScrollViewer ScrollOwner { get => _scrollOwner; set => _scrollOwner = value; }


        public void LineDown()
        {
            SetVerticalOffset(VerticalOffset + 10);
        }

        public void LineLeft()
        {
            SetHorizontalOffset(HorizontalOffset - 10);
        }

        public void LineRight()
        {
            SetHorizontalOffset(HorizontalOffset + 10);
        }

        public void LineUp()
        {
            SetVerticalOffset(VerticalOffset - 10);
        }

        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            return rectangle;
        }

        public void MouseWheelDown()
        {
            SetVerticalOffset(this.VerticalOffset + 10);
        }

        public void MouseWheelLeft()
        {
            SetHorizontalOffset(HorizontalOffset - 10);
        }

        public void MouseWheelRight()
        {
            SetHorizontalOffset(HorizontalOffset +10);
        }

        public void MouseWheelUp()
        {
            SetVerticalOffset(this.VerticalOffset - 10);
        }

        public void PageDown()
        {
            SetVerticalOffset(VerticalOffset + ViewportHeight);
        }

        public void PageLeft()
        {
            SetHorizontalOffset(HorizontalOffset - ViewportWidth);
        }

        public void PageRight()
        {
            SetHorizontalOffset(HorizontalOffset + ViewportWidth);
        }

        public void PageUp()
        {
            SetVerticalOffset(VerticalOffset - ViewportHeight);
        }

        public void SetHorizontalOffset(double offset)
        {
            offset = CalculateHorizontalOffset(offset);

            _offset.X = offset;

            if (_scrollOwner != null)
                _scrollOwner.InvalidateScrollInfo();

            Scroll(offset, VerticalOffset);

            // Force us to realize the correct children
            InvalidateMeasure();
        }

        public void SetVerticalOffset(double offset)
        {
            offset = CalculateVerticalOffset(offset);

            _offset.Y = offset;

            if (_scrollOwner != null)
                _scrollOwner.InvalidateScrollInfo();

            Scroll(HorizontalOffset, offset);
        }

        private double CalculateHorizontalOffset(double offset)
        {
            if (offset < 0 || _viewport.Width >= _extent.Width)
            {
                offset = 0;
            }
            else
            {
                if (offset + _viewport.Width >= _extent.Width)
                {
                    offset = _extent.Width - _viewport.Width;
                }
            }
            return offset;
        }

        private void Scroll(double xOffset, double yOffset)
        {
            _trans.X = -xOffset;
            _trans.Y = -yOffset;
        }

        private double CalculateVerticalOffset(double offset)
        {
            if (offset < 0 || _viewport.Height >= _extent.Height)
            {
                offset = 0;
            }
            else
            {
                if (offset + _viewport.Height >= _extent.Height)
                {
                    offset = _extent.Height - _viewport.Height;
                }
            }
            return offset;
        }
    }
}
