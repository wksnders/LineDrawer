using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineGeneratorModel
{
	/// <summary>
	/// a collection of dictionaries of all objects needing to be displayed by the view or used by the model
	/// </summary>
    public class ModelObjects
    {
		/// <summary>
		/// Size of the Display (Square)
		/// </summary>
		public int DisplaySize
		{
			get; private set;
		}
		/// <summary>
		/// single arguement constructor that creates a model with the specified display size (any other values are set to default)
		/// </summary>
		/// <param name="DispSize"></param>
		public ModelObjects(int DispSize) /* : this(DispSize)*/{// TODO uncomment when more values are needed

			DisplaySize = DispSize;
		}
		/*
		/// <summary>
		/// TODO uncomment when more values are needed
		/// full constructor that creates a model with the specified values
		/// called by other constructors.
		/// </summary>
		public ModelObjects(int DispSize)
		{
			DisplaySize = DispSize;
		}
		*/
	}
	public class Points
	{

	}
}
