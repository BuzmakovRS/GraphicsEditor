using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace GraphicsEditor.Models
{
    public class PainterParams
    {

        public SolidColorBrush    borderColor { get; set; }

        public SolidColorBrush    fillColor { get; set; }

        public int StrokeThikness { get; set; }

    }
}
