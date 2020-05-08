using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PrintDemo
{
    public class OrderDocumentRenderer : IDocumentRenderer
    {
        public void Render(FlowDocument doc, Object data)
        {
            TableRowGroup group = doc.FindName("OrderDetails") as TableRowGroup;
            foreach (var item in ((Order)data).OrderDetails)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell(new Paragraph(new Run(item)));
                row.Cells.Add(cell);
                group.Rows.Add(row);
            }
        }
    }
}
