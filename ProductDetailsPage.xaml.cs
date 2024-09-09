namespace XBeautyApp;

public partial class ProductDetailsPage : ContentPage
{
    private readonly Product _product;

    public ProductDetailsPage(Product product)
    {
        InitializeComponent();
        _product = product;
        BindingContext = _product;
    }

    private async void OnProductLinkClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(_product.ProductLink);
    }

    private async void OnWebsiteLinkClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(_product.WebsiteLink);
    }
}