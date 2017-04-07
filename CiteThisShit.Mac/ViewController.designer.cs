// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CiteThisShit.Mac
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		WebKit.WebView ResultWebView { get; set; }

		[Outlet]
		AppKit.NSTextField SearchTextbox { get; set; }

		[Action ("SearchButton:")]
		partial void SearchButton (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (SearchTextbox != null) {
				SearchTextbox.Dispose ();
				SearchTextbox = null;
			}

			if (ResultWebView != null) {
				ResultWebView.Dispose ();
				ResultWebView = null;
			}
		}
	}
}
