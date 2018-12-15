using LineGeneratorModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingPanel
{
	/// <summary>
	/// does the work to draw the model.
	/// </summary>
    public class DrawingPanel : Panel
	{
		private ModelObjects TheDisplayModel;

		/// <summary>
		/// creates a new drawing panel with a world object
		/// </summary>
		/// <param name="w"></param>
		public DrawingPanel(ModelObjects w) : base()
		{
			DoubleBuffered = true;
			TheDisplayModel = w;
		}

		/// <summary>
		/// Helper method for DrawObjectWithTransform
		/// </summary>
		/// <param name="size">The world (and image) size</param>
		/// <param name="w">The worldspace coordinate</param>
		/// <returns></returns>
		private static int DisplaySpaceToImageSpace(int size, double w)
		{
			return (int)w + size / 2;
		}

		/// <summary>
		/// A delegate for DrawObjectWithTransform
		/// Methods matching this delegate can draw whatever they want using e  
		/// </summary>
		/// <param name="o">object to draw</param>
		/// <param name="e"></param>
		public delegate void ObjectDrawer(object o, PaintEventArgs e);




		/// <summary>
		/// This method performs a translation and rotation to drawn an object in the display.
		/// </summary>
		/// <param name="e">PaintEventArgs to access the graphics (for drawing)</param>
		/// <param name="o">The object to draw</param>
		/// <param name="worldSize">The size of one edge of the world (assuming the world is square)</param>
		/// <param name="worldX">The X coordinate of the object in world space</param>
		/// <param name="worldY">The Y coordinate of the object in world space</param>
		/// <param name="angle">The orientation of the objec, measured in degrees clockwise from "up"</param>
		/// <param name="drawer">The drawer delegate. After the transformation is applied, the delegate is invoked to draw whatever it wants</param>
		private void DrawObjectWithTransform(PaintEventArgs e, object o, int worldSize, double worldX, double worldY, double angle, ObjectDrawer drawer)
		{
			// Perform the transformation
			int x = DisplaySpaceToImageSpace(worldSize, worldX);
			int y = DisplaySpaceToImageSpace(worldSize, worldY);
			e.Graphics.TranslateTransform(x, y);
			e.Graphics.RotateTransform((float)angle);
			// Draw the object 
			drawer(o, e);
			// Then undo the transformation
			e.Graphics.ResetTransform();
		}



		
		/// <summary>
		/// example delegate to start new drawing delegates
		/// 
		/// 
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		private void exampleDrawer(object o, PaintEventArgs e)
		{
			//example exampleObject = o as example; object will need to be casted back into it's type to beable to use it's attributes and draw it properly.
		}

	


		/// <summary>
		/// This method is invoked when the DrawingPanel needs to be re-drawn
		/// redraws the updated ships projectiles and stars then invokes the base OnPaint
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			//draw the background (black background TODO Setting to change this?)
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			using (System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
			{
				//drawn starting from the top-left corner.
				Rectangle r = new Rectangle(0, 0, TheDisplayModel.DisplaySize, TheDisplayModel.DisplaySize);
				e.Graphics.FillRectangle(blackBrush, r);
			}
			//draw everything else 

			// Do anything that Panel (from which we inherit) needs to do
			base.OnPaint(e);
		}


	}
}

