// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MusicMatcher.App.iOS
{
	[Register ("MasterViewController")]
	partial class MasterViewController
	{
		[Outlet]
		UIKit.UIBarButtonItem _teachButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_teachButton != null) {
				_teachButton.Dispose ();
				_teachButton = null;
			}
		}
	}
}
