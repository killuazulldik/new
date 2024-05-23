using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace barangayrecordandmanagementSystem
{
    class picturecircle: PictureBox

    {
        protected override void OnPaint(PaintEventArgs pe) {

            GraphicsPath grapath = new GraphicsPath();
            grapath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grapath);
            base.OnPaint(pe);
        }
    }
}
