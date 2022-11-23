using System.Collections.ObjectModel;

namespace CollectionViewSample;

public partial class MainPage : ContentPage
{
   private ObservableCollection<string> _strings;
   private bool _isInitialized;

   public MainPage()
	{
		InitializeComponent();
      Appearing += HandleOnAppearing;
   }

   private void HandleOnAppearing(object sender, EventArgs e)
   {
      if (!_isInitialized)
      {
         _isInitialized = true;
         _strings = new ObservableCollection<string>();
         for (int i = 0; i < 50000; i++)
         {
            _strings.Add($"string {i}");
         }

         _collectionView.ItemsSource = _strings;
      }
   }

   private void HandleOnUpdateItemInCollectionView(object sender, EventArgs e)
   {
      Random random = new Random();
      var randomNumber = random.Next(1, 100);
      //_strings[5] = $"Random number {randomNumber}";
      _strings.RemoveAt(2);;
   }
}

