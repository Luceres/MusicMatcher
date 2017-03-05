using System;
using ReactiveUI;
using MusicMatcher.Common;
using Foundation;

namespace MusicMatcher.App.iOS
{
	public partial class SampleCell : ReactiveTableViewCell<Song>
	{
        public static readonly NSString CellIdentifier = new NSString("SampleCell");
	    public const float SizeHint = 60;

        public SampleCell(IntPtr handle) : base(handle)
        {
        }

        public void Initialize()
        {
            this.Bind(ViewModel, x => x.Titel, v => v._titel.Text);
            this.Bind(ViewModel, x => x.Artist, v => v._subTitel.Text);
            this.Bind(ViewModel, x => x.Rating, v => v._info.Text);

            ////this.WhenAnyValue(v => v.ViewModel.Image).BindTo(
            ////    this,
            ////    v => v._image
            ////);
        }
	}
}
