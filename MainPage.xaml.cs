using System.Collections.ObjectModel;

namespace XBeautyApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string query = SearchBar.Text;
        if (string.IsNullOrWhiteSpace(query))
            return;

        try
        {
            var products = await global::ApiService.SearchProducts(query);
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Product selectedProduct)
        {
            await Navigation.PushAsync(new ProductDetailsPage(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}