using System;
using AppKit;
using Foundation;
using CiteThisShit.MacLib;

namespace CiteThisShit.Mac
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Do any additional setup after loading the view.
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
		async partial void SearchButton(NSButton sender)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
		{
			

		}

	}
}
