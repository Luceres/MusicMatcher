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
	[Register ("SampleCell")]
	partial class SampleCell
	{
		[Outlet]
		UIKit.UIImageView _image { get; set; }

		[Outlet]
		UIKit.UILabel _info { get; set; }

		[Outlet]
		UIKit.UILabel _subTitel { get; set; }

		[Outlet]
		UIKit.UILabel _titel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_image != null) {
				_image.Dispose ();
				_image = null;
			}

			if (_titel != null) {
				_titel.Dispose ();
				_titel = null;
			}

			if (_subTitel != null) {
				_subTitel.Dispose ();
				_subTitel = null;
			}

			if (_info != null) {
				_info.Dispose ();
				_info = null;
			}
		}
	}
}
