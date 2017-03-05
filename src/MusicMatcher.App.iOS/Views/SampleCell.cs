using System;
using ReactiveUI;
using MusicMatcher.Common;
using Foundation;

namespace MusicMatcher.App.iOS
{
	public partial class SampleCell : ReactiveTableViewCell, IViewFor<IArtist>
	{
        public static readonly NSString CellIdentifier = new NSString("Cell");
	    public const float SizeHint = 46;

        public SampleCell(IntPtr handle) : base(handle)
        {
        }

        private IArtist _viewModel;
        public IArtist ViewModel
        {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as IArtist; }
        }

        public void Initialize()
        {
            this.WhenAnyValue(v => v.ViewModel.Name).BindTo(
                this,
                v => v.TextLabel.Text);
        }
	}
}
